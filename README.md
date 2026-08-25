# Mini-Projeto-SCTEC — Motor de Vistoria Veicular

Sistema de console em C#/.NET para apoiar a vistoria técnica de veículos (carros,
motos e caminhões) antes da compra/revenda por uma concessionária, calculando
automaticamente uma nota de aprovação e apontando o que precisa ser reparado.

---

## 1. O que o sistema faz e para que serve

O Sistema simula o processo de vistoria veicular feito por uma oficina/
concessionária ao receber um veículo:

1. O usuário cadastra os dados do veículo (marca, modelo, ano, quilometragem) e
   informa se é um **Carro**, uma **Moto** ou um **Caminhão**.
2. O sistema apresenta o checklist obrigatório daquele tipo de veículo,
   itens genéricos (nível de óleo, bateria, documentação) e itens
   específicos da categoria (ex.: estepe e triângulo para carro; tacógrafo para caminhão).
3. Para cada item do checklist, o usuário informa o estado encontrado:
   `Bom`, `Regular` ou `Ruim`.
4. O sistema converte essas respostas em uma pontuação, calcula o
   percentual de aprovação do veículo e classifica o resultado
   (Aprovado com Excelência / Aprovado com Apontamentos / Reprovado).
5. Por fim, imprime um **relatório no terminal** com os itens críticos, os
   itens de atenção e uma recomendação dos serviços que a oficina deve
   executar antes de liberar o veículo.

---

## 2. Como executar, passo a passo, do zero

### Pré-requisitos

- **.NET SDK 10.0** (ou superior) instalado.
  Verifique com:
  ```bash
  dotnet --version
  ```
  Se não tiver o SDK, baixe em https://dotnet.microsoft.com/download.
- Um terminal (PowerShell, CMD, bash, zsh...).
- Git (opcional, apenas para clonar o repositório).

### Passo a passo

1. **Clone o repositório** (ou baixe o ZIP e extraia):
   ```bash
   git clone https://github.com/JunkesGui/Mini-Projeto-SCTEC.git
   cd Mini-Projeto-SCTEC
   ```

2. **Entre na pasta do projeto executável**:
   ```bash
   cd src/AutoCheck.ConsoleApp
   ```

3. **Compile o projeto** (opcional, o `dotnet run` já compila sozinho):
   ```bash
   dotnet build
   ```

4. **Execute o sistema**:
   ```bash
   dotnet run
   ```

5. **Use o menu interativo** que aparece no terminal:
   ```
   ===================================================
   Bem vindo ao Sistema de Vistoria Técnica Automotiva
   ===================================================
   Escolha uma opção para continuar:
   1 - Realizar Nova Vistoria
   2 - Exibir Relatório de Vistorias
   0 - Sair
   ```
   - Escolha **1** para cadastrar um veículo, preencher o checklist item a
     item e ver o relatório final
   - Escolha **2** para reimprimir o relatório de todas as vistorias já
     realizadas naquela execução do programa.
   - Escolha **0** para encerrar.

---

## 3. Regra de cálculo adotada (percentual de aprovação)

Cada item do checklist recebe uma pontuação de acordo com o status observado:

Bom: 10     
Regular: 5      
Ruim: 0      

O percentual de aprovação é calculado como:

```
Percentual (%) = (PontuacaoObtida / PontuacaoMaximaPossivel) × 100
```

onde `PontuacaoMaximaPossivel = TotalDeItens × 10` (ou seja, a nota que o
veículo teria se todos os itens estivessem "Bom").

A divisão é feita pela pontuação máxima possível (e não por uma nota fixa) torna a regra justa independentemente de quantos itens o checklist tem. Carro, moto e caminhão têm checklists de tamanhos diferentes, mas o percentual final é sempre comparável entre eles (0 a 100%).

---

## 4. Arquitetura cliente-servidor: o que é e como aparece no projeto

### O conceito

Arquitetura **cliente-servidor** é um modelo em que a responsabilidade de um
sistema é dividida em dois papéis:

- **Cliente**: é quem interage com o usuário — recebe a entrada (o que a
  pessoa digita/clica) e mostra a saída (o que ela vê na tela). O cliente
  normalmente não decide regras de negócio, apenas coleta dados e exibe
  resultados.
- **Servidor**: é quem concentra a lógica de negócio e o processamento,
  recebe os dados enviados pelo cliente, aplica as regras do domínio (cálculos,
  validações, decisões) e devolve um resultado.

### Como isso aparece neste projeto

O código foi organizado seguindo a divisão de papéis que a arquitetura cliente-servidor propõe, através de pastas e classes separadas:

```
src/AutoCheck.ConsoleApp/
├── Program.cs              
├── Models/                 
│   ├── ItemVistoria.cs
│   ├── Veiculo.cs
│   ├── Carro.cs
│   ├── Moto.cs
│   └── Caminhao.cs
└── Services/                
    └── MotorVistoria.cs
```

- **`Program.cs`** faz o papel do cliente: exibe o menu, lê o que o usuário
  digita (`Console.ReadLine`), valida formato básico de entrada e imprime o
  relatório formatado. Ele não calcula pontuação nem decide a
  classificação do veículo, apenas repassa os dados coletados.
- **`Services/MotorVistoria.cs`** faz o papel do servidor: recebe um objeto
  `Veiculo` já preenchido, processa a pontuação, calcula o percentual
  , aplica as regras de classificação e monta as listas de
  pendências e recomendações, tudo isolado da interface. Ele
  devolve um `ResultadoVistoria` pronto para ser exibido.
- **`Models/`** representa o "contrato de dados" trocado entre os dois lados
  (`Veiculo`, `ItemVistoria` e suas subclasses).

---

**Link do vídeo: https://www.youtube.com/watch?v=eBqxbarAmpo**
