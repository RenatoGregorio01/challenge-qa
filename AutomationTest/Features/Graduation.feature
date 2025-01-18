Feature: Inscricao de Usuario para curso de Graduacao

  Scenario: Inscricao graduação ao portal no Chrome
    Given que estou na pagina de login Grupo A
    When eu selecionar o nivel de ensino
	When selecionar um curso
    When preencher o formulario de cadastro
    When fazer login com meu usuario cadastrado
    Then devo visualizar a pagina interna do candidato