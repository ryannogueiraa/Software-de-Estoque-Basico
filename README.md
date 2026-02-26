<h1 align="center">📦 Software de Estoque Básico</h1>

<p align="center">
  <img src="https://readme-typing-svg.herokuapp.com?color=00F7FF&size=22&center=true&vCenter=true&width=650&lines=Sistema+de+Controle+de+Estoque;C%23+%7C+.NET+Console+Application;CRUD+com+Persistência+em+Arquivo;Validação+de+Dados+e+Menu+Interativo" />
</p>

<p align="center">
  <img src="https://img.shields.io/badge/C%23-512BD4?style=for-the-badge&logo=csharp&logoColor=white"/>
  <img src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=dotnet&logoColor=white"/>
  <img src="https://img.shields.io/badge/System.IO-File%20Handling-blue?style=for-the-badge"/>
</p>

---

## 🚀 Sobre o Projeto

O **Software de Estoque Básico** é um sistema desenvolvido em **C# (.NET Console Application)** com o objetivo de gerenciar produtos utilizando armazenamento em arquivo local.

Este projeto demonstra aplicação prática de:

- Estruturas de controle
- Manipulação de arquivos
- Validação de dados
- Operações CRUD
- Organização lógica de sistema

---

## 🧠 Funcionalidades

✔️ Adicionar novo produto  
✔️ Remover produto pelo código  
✔️ Editar nome, quantidade ou valor  
✔️ Visualizar lista completa  
✔️ Geração automática de código sequencial  
✔️ Validação de entradas numéricas  
✔️ Persistência automática em arquivo `.txt`  

---

## 📂 Como Funciona o Armazenamento

Os dados são armazenados no arquivo: produto.txt, onde
cada produto é salvo no formato:
00001| Nome: Mouse| Quantidade: 10| Valor: 59.90

🔹 Código gerado automaticamente com 5 dígitos (`D5`)  
🔹 Separação por `|`  
🔹 Leitura e reescrita do arquivo para atualização  

O arquivo é criado automaticamente caso não exista.

---

## 🛠️ Conceitos Técnicos Aplicados

🔁 Loop principal com `while(true)`  
🔀 Estrutura `switch-case`  
📁 Manipulação de arquivos com `System.IO`:
- `File.Exists`
- `File.ReadAllLines`
- `File.AppendAllText`
- `File.WriteAllLines`

🧮 Validação com:
- `int.TryParse`
- `float.TryParse`

🔎 Uso de LINQ (`Where`) para remoção de registros  
🧱 Manipulação de strings com:
- `Split`
- `Replace`
- `StartsWith`

🎯 Formatação:
- Código com `"D5"`
- Valor com `"F2"`

---

## ▶️ Como Executar

1️⃣ Clone o repositório:

```bash
git clone https://github.com/ryannogueiraa/Software-de-Estoque-Basico.git
