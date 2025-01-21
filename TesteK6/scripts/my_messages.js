import http from 'k6/http';
import { check, sleep } from 'k6';
import { SharedArray } from 'k6/data';
import { htmlReport } from "https://raw.githubusercontent.com/benc-uk/k6-reporter/main/dist/bundle.js";

// Carregar usuários de um arquivo JSON
const users = new SharedArray('User data', () => JSON.parse(open('../data/data.json')));

export let options = {
    scenarios: {
        load_test_100_users: {
            executor: 'constant-vus',
            vus: 100,
            duration: '30s',
        },
        load_test_500_users: {
            executor: 'constant-vus',
            vus: 500,
            duration: '30s',
        },
        load_test_1000_users: {
            executor: 'constant-vus',
            vus: 1000,
            duration: '30s',
        },
    },
};

export default function () {
    const randomUser = users[Math.floor(Math.random() * users.length)];

    const loginUrl = 'https://test.k6.io/login.php';
    const loginPayload = {
        login: randomUser.user,
        password: randomUser.password,
    };

    const loginParams = {
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded',
        },
    };

    const loginResponse = http.post(loginUrl, loginPayload, loginParams);

    // Validar resposta do POST
    check(loginResponse, {
        'POST status is 200': (r) => r.status === 200,
        'HTML contains welcome message with username': (r) =>
            r.body.includes(`<h2>Welcome, ${randomUser.user}!</h2>`),
    });

    const messagesUrl = 'https://test.k6.io/my_messages.php';
    const getResponse = http.get(messagesUrl);

    // Validar resposta do GET
    check(getResponse, {
        'GET status is 200': (r) => r.status === 200,
        'HTML contains table header': (r) => r.body.includes('<table'),
        'HTML contains "From" column': (r) => r.body.includes('<td><b>From:</b></td>'),
    });

    sleep(1); // Pausa entre as requisições
}

// Função para gerar relatório HTML com data e horário no nome
export function handleSummary(data) {
    const date = new Date();
    const formattedDate = `${date.getFullYear()}-${String(date.getMonth() + 1).padStart(2, '0')}-${String(date.getDate()).padStart(2, '0')}`;
    const formattedTime = `${String(date.getHours()).padStart(2, '0')}-${String(date.getMinutes()).padStart(2, '0')}-${String(date.getSeconds()).padStart(2, '0')}`;
    const timestamp = `${formattedDate}_${formattedTime}`;

    return {
        [`./reports/report_my_messages_${timestamp}.html`]: htmlReport(data), // Ajuste aqui
    };
}