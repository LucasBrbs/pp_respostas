# Questão 1 
## a) Compare-os no nível conceitual.
## b) Ilustre as diferenças entre os mesmos em código.

A diferença principal entre eles é que o DAO  separa as persistencias do negócio com o banco de dados (persistencia) 
o Data mapper APENAS TRADUZ o objeto para o banco e ncessecita de um Repository/Service ou seja necessida de mais 
uma camada de abstração.

O repository por sua vez é usada como uma camada de abstracao para esses dois casos. Ele organiza e expõe métodos amigáveis para a aplicação, podendo aplicar regras de negócio ou validações antes de persistir os dados.

## c) Explique a afirmação abaixo ilustrando com código o que você entendeu por agregado e invariantes:

 No contexto de Domain-Driven Design Repository trabalha especificamente com agregados. Esta
 é uma das características fundamentais que distingue o padrão Repository de outras abstrações de
 acesso a dados. Segundo Eric Evans:
 • Cada Repository gerencia apenas um tipo de agregado (não entidades individuais dentro do
 agregado)
 • O Repository recupera e persiste o agregado como uma unidade completa
 • Mantém a consistência e as invariantes do agregado”

Agregado - > conjunto de entidades e objetos de valor que são tratados como uma unidade de consistência e de persistência.
Invariante - > regra de negócio que deve sempre ser verdadeira para manter o agregado válido.
