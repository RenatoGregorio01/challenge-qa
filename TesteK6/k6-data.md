 Estratégia de Massa de Dados para Testes com K6
==============================================

Introdução
A massa de dados é fundamental para testes de desempenho e carga com K6. Esta estratégia visa garantir dados realistas, escaláveis e eficientes.

Objetivos
- Gerar dados realistas e variados
- Minimizar dependência de APIs externas
- Otimizar desempenho e escalabilidade
- Facilitar manutenção e atualização

## Estratégia

### 1. Tipos de Dados
- Dados estáticos: JSON, CSV
- Dados dinâmicos: k6/encoding
- Dados mockados: json-server

### 2. Fontes de Dados
- Arquivos locais: JSON, CSV, XML
- Bancos de dados: MySQL, PostgreSQL, MongoDB
- APIs públicas: jsonplaceholder.typicode.com

### 3. Gerenciamento de Dados
- k6/encoding: dados aleatórios
- k6/data: carregar dados de arquivos
- json-server: simular APIs

### 4. Otimização
- Cache: reduzir requisições
- Compressão: reduzir tamanho dos dados
- Paralelismo: melhorar desempenho

### 5. Segurança
- Criptografia: proteger dados sensíveis
- Autenticação: controlar acesso
- Validação: garantir integridade dos dados
