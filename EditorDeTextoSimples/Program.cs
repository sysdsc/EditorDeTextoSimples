using System;
using System.IO;
using System.Text;

class Program
{
    static StringBuilder content = new StringBuilder();
    static string fileName = "";

    static void Main()
    {
        Console.WriteLine("Digite 'abrir [nome do arquivo]' para abrir um arquivo, 'novo [nome do arquivo]' para criar um novo arquivo, 'salvar' para salvar o arquivo, ou 'sair' para sair. Quando estiver editando um arquivo, digite 'EOF' em uma nova linha para terminar a edição.");

        while (true)
        {
            string input = Console.ReadLine();

            if (input.ToLower() == "sair")
            {
                break;
            }
            else if (input.ToLower().StartsWith("abrir "))
            {
                fileName = input.Substring(6);
                try
                {
                    string text = File.ReadAllText(fileName);
                    content.Clear();
                    content.Append(text);
                    Console.WriteLine("Conteúdo do arquivo:");
                    Console.WriteLine(content.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro ao abrir o arquivo: " + e.Message);
                }
            }
            else if (input.ToLower().StartsWith("novo "))
            {
                fileName = input.Substring(5);
                content.Clear();
                Console.WriteLine($"Novo arquivo '{fileName}' criado. Digite o conteúdo abaixo (Digite 'EOF' em uma nova linha quando terminar):");
                while (true)
                {
                    string line = Console.ReadLine();
                    if (line == "EOF") break;
                    content.AppendLine(line);
                }
            }
            else if (input.ToLower() == "salvar")
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    Console.WriteLine("Nenhum arquivo aberto ou criado. Use 'novo [nome do arquivo]' para criar um arquivo.");
                    continue;
                }

                try
                {
                    File.WriteAllText(fileName, content.ToString());
                    Console.WriteLine($"Arquivo '{fileName}' salvo com sucesso!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro ao salvar o arquivo: " + e.Message);
                }
            }
            else
            {
                Console.WriteLine("Comando desconhecido. Por favor, digite um comando válido.");
            }
        }
    }
}
