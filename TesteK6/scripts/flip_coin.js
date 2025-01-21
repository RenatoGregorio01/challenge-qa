import http from 'k6/http';
import { check, sleep } from 'k6';
import { htmlReport } from "https://raw.githubusercontent.com/benc-uk/k6-reporter/main/dist/bundle.js";

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
  
  let getUrl = 'https://test.k6.io/flip_coin.php';
  let getResponse = http.get(getUrl);

  check(getResponse, {
    'GET status is 200': (r) => r.status === 200,
    'GET response time is less than 200ms': (r) => r.timings.duration < 200,
  });

  sleep(1);  
}

export function handleSummary(data) {
    const date = new Date();
    const formattedDate = `${date.getFullYear()}-${String(date.getMonth() + 1).padStart(2, '0')}-${String(date.getDate()).padStart(2, '0')}`;
    const formattedTime = `${String(date.getHours()).padStart(2, '0')}-${String(date.getMinutes()).padStart(2, '0')}-${String(date.getSeconds()).padStart(2, '0')}`;
    const timestamp = `${formattedDate}_${formattedTime}`;

    return {
        [`./reports/report_flip_coin_${timestamp}.html`]: htmlReport(data), 
    };
}
