### Questão 1 
## Diferença DAO, DATA MAPPER, Repository

A diferença principal entre eles é que o DAO  separa as persistencias do negócio com o banco de dados (persistencia) 
o Data mapper APENAS TRADUZ o objeto para o banco e ncessecita de um Repository/Service ou seja necessida de mais 
uma camada de abstração.

O repository por sua vez é usada como uma camada de abstracao para esses dois casos. Ele organiza e expõe métodos amigáveis para a aplicação, podendo aplicar regras de negócio ou validações antes de persistir os dados.

