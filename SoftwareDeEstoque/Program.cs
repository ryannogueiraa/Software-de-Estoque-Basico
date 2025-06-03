using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SoftwareDeEstoque
{
    internal class Program
    {
        static void Main(string[] args)
        {
 
           while (true)
                {
                  Console.Clear();
                  Console.WriteLine("Software de Estoque Personalizado:");
                  Console.WriteLine("Selecione uma opção: ");
                  Console.WriteLine("1 - Adicionar novo produto;");
                  Console.WriteLine("2 - Remover produto;");
                  Console.WriteLine("3 - Editar Produtos;");
                  Console.WriteLine("4 - Ver lista de produtos;");
                  Console.WriteLine("5 - Fechar programa...");

                  string opcao = Console.ReadLine();

                  switch (opcao)
                  {
                     case "1":
                        Console.Clear();
                        AdicionarProduto(); 
                        break;

                     case "2":
                        Console.Clear();
                        RemoverProduto();
                        break;

                     case "3":
                        Console.Clear();
                        EditarProduto();
                        break;

                     case "4":
                        Console.Clear();
                        VisualizarLista();
                        break;
                           

                     case "5":
                        Console.Clear();
                        Console.WriteLine("Fechando o programa...");
                        return; 

                     default:
                        Console.WriteLine("Opção inválida ou não implementada.");
                        break;
                  }

                  Console.WriteLine("Pressione qualquer tecla para continuar...");
                  Console.ReadKey();
                }
            }

        


        static void AdicionarProduto()
        {
            Console.WriteLine("Adicionar produto...");

            string nomeproduto;
            int qntdproduto;
            float valorproduto;
            bool ok;

            do
            {
                Console.Write("Digite o nome do produto: ");
                nomeproduto = Console.ReadLine();
                ok = (!string.IsNullOrEmpty(nomeproduto));
                if (!ok)
                {
                    Console.WriteLine("Erro, tente novamente...");
                }

            } while (!ok);

            do
            {
                Console.WriteLine("Digite a quantidade do produto: ");
                string sqntdproduto;
                sqntdproduto = Console.ReadLine();
                ok = (int.TryParse(sqntdproduto, out qntdproduto) && qntdproduto > 0);
                if (!ok)
                {
                    Console.WriteLine("Erro, tente novamente... (Dica: tente digitar um número maior que Zero.)");
                }

            } while (!ok);

            do
            {
                Console.WriteLine("Digite o valor do produto: ");
                string svalorproduto;
                svalorproduto = Console.ReadLine();
                ok = (float.TryParse(svalorproduto, out valorproduto) && valorproduto > 0);
                if (!ok)
                {
                    Console.WriteLine("Erro, tente novamente...");
                }

            } while (!ok);

            // Verifica se o arquivo "produtos.txt" existe:
            // Se existir, lê todas as linhas e conta quantas existem, ou seja, quantos produtos já estão cadastrados.
            // Se não existir, considera que não há produtos ainda (0).
            int qntdprodutosregistrados = File.Exists("produtos.txt") ? File.ReadAllLines("produtos.txt").Length : 0;

            // Gera um código para o novo produto, baseado na quantidade de produtos existentes + 1.
            // O código é formatado com 5 dígitos, com zeros à esquerda (ex: 00001, 00002, etc).
            string codigo = (qntdprodutosregistrados + 1).ToString("D5");

            // Cria a linha de texto que será salva no arquivo, juntando os dados do produto.
            string linha = codigo + "| Nome: " + nomeproduto + "| Quantidade: " + qntdproduto + "| Valor: " + valorproduto.ToString("F2");

            // Adiciona essa linha no final do arquivo "produtos.txt".
            // Se o arquivo não existir, ele será criado automaticamente.
            // Environment.NewLine adiciona uma quebra de linha para separar os registros.
            File.AppendAllText("produtos.txt", linha + Environment.NewLine);

            // Mostra uma mensagem confirmando que o produto foi adicionado com sucesso.
            Console.WriteLine("Produto adicionado com sucesso!");

            // Exibe na tela os detalhes do produto recém-adicionado, incluindo o código gerado.
            Console.WriteLine("Código: " + codigo + " | Nome: " + nomeproduto + " | Quantidade: " + qntdproduto + " | Valor: R$ " + valorproduto.ToString("F2"));
        }

        static void RemoverProduto()
        {
            
            
           Console.WriteLine("Remover produto...");

           if (!File.Exists("produtos.txt"))
           {
              Console.WriteLine("Nenhum produto cadastrado.");
              return;
           }

           string[] linhas = File.ReadAllLines("produtos.txt");

           if (linhas.Length == 0)
           {
              Console.WriteLine("Nenhum produto cadastrado.");
              return;
           }

           Console.WriteLine("Lista de produtos:");
           foreach (string linha in linhas)
           {
               Console.WriteLine(linha);
           }

           Console.Write("Digite o código do produto que deseja remover: ");
           string codigo = Console.ReadLine();

          // Verifica se encontrou o código
          bool encontrado = false;

           var novasLinhas = linhas.Where(linha =>
           {
              if (linha.StartsWith(codigo + "|"))
              {
                  encontrado = true;
                  return false; // Remove essa linha
              }
              return true; // Mantém a linha
              }).ToArray();

           if (encontrado)
           {
               File.WriteAllLines("produtos.txt", novasLinhas);
               Console.WriteLine("Produto removido com sucesso!");
           }
          else
          {
              Console.WriteLine("Produto não encontrado.");
          }
        }

        static void EditarProduto()
        {
            Console.WriteLine("Editar produto...");

            if (!File.Exists("produtos.txt"))
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                return;
            }

            string[] linhas = File.ReadAllLines("produtos.txt");

            Console.Write("Digite o código do produto que deseja editar: ");
            string codigoproduto = Console.ReadLine();

            bool encontrado = false;

            for (int i = 0; i < linhas.Length; i++)
            {
                if (linhas[i].StartsWith(codigoproduto))
                {
                    encontrado = true;
                    Console.WriteLine("Produto encontrado: ");
                    Console.WriteLine(linhas[i]);

                    // Extrair dados atuais
                    string[] partes = linhas[i].Split('|');
                    string nome = partes[1].Replace(" Nome: ", "").Trim();
                    string quantidadeTexto = partes[2].Replace(" Quantidade: ", "").Trim();
                    string valorTexto = partes[3].Replace(" Valor: ", "").Trim();

                    int quantidade = int.Parse(quantidadeTexto);
                    float valor = float.Parse(valorTexto);

                    // Perguntar se quer alterar nome
                    Console.Write("Deseja alterar o nome? (S/N): ");
                    if (Console.ReadLine().ToUpper() == "S")
                    {
                        Console.Write("Digite o novo nome: ");
                        nome = Console.ReadLine();
                    }

                    // Perguntar se quer alterar quantidade
                    Console.Write("Deseja alterar a quantidade? (S/N): ");
                    if (Console.ReadLine().ToUpper() == "S")
                    {
                        Console.Write("Digite a nova quantidade: ");
                        int novaQuantidade;
                        while (!int.TryParse(Console.ReadLine(), out novaQuantidade) || novaQuantidade < 0)
                        {
                            Console.Write("Valor inválido. Digite a quantidade (número inteiro positivo): ");
                        }
                        quantidade = novaQuantidade;
                    }

                    // Perguntar se quer alterar valor
                    Console.Write("Deseja alterar o valor? (S/N): ");
                    if (Console.ReadLine().ToUpper() == "S")
                    {
                        Console.Write("Digite o novo valor: ");
                        float novoValor;
                        while (!float.TryParse(Console.ReadLine(), out novoValor) || novoValor <= 0)
                        {
                            Console.Write("Valor inválido. Digite um valor maior que zero: ");
                        }
                        valor = novoValor;
                    }

                    // Montar linha atualizada com concatenação +
                    linhas[i] = codigoproduto + "| Nome: " + nome + "| Quantidade: " + quantidade + "| Valor: " + valor.ToString("F2");

                    Console.WriteLine("Produto atualizado com sucesso!");
                    Console.WriteLine(linhas[i]);

                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Produto com esse código não encontrado.");
            }
            else
            {
                // Salvar alterações no arquivo
                File.WriteAllLines("produtos.txt", linhas);
            }
        }


        static void VisualizarLista()
        {
            Console.WriteLine("Lista de produtos: ");

            if (File.Exists("produtos.txt"))
            {
                string[] linhas = File.ReadAllLines("produtos.txt");

                if(linhas.Length == 0)
                {
                    Console.WriteLine("Nenhum produto cadastrado.");
                }
                else
                {
                    foreach (string linha in linhas)
                    {
                        Console.WriteLine(linha);
                    }
                }
            }
            else
            {
                Console.WriteLine("Nenhum produto cadastrado encontrado.");
            }
        }   



    }



    
}
