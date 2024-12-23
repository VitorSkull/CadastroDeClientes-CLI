using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CadastroDeClientes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Cliente> clientes = new List<Cliente>();

            bool x = true;

            while (x == true)
            {
                Console.WriteLine("Bem vindo");
                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("1 - Adicionar Cliente");
                Console.WriteLine("2 - Editar Cliente");
                Console.WriteLine("3 - Excluir Cliente");
                Console.WriteLine("4 - Exibir Cliente");
                Console.WriteLine("5 - Sair");

                string opcao = Console.ReadLine();

                switch(opcao)
                {
                    case "1":
                        Console.WriteLine("Nome: ");
                        string nome = null;
                        string email = null;
                        string endereco = null;
                        string cpf = null;
                        string telefone = null;

                        while (nome == null || !nome.All(c => char.IsLetter(c) || c == ' '))
                        {
                            nome = Console.ReadLine();
                            if (string.IsNullOrEmpty(nome))
                            {
                                nome = null;
                            }
                        }
                        Console.WriteLine("E-mail: ");
                        while (email == null)
                        {
                            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                            email = Console.ReadLine();
                            Match match = regex.Match(email);
                            if (string.IsNullOrEmpty(email) || !match.Success)
                            {
                                email = null;
                                Console.WriteLine("Escreva um e-mail valido.");
                            }
                        }

                        Console.WriteLine("Endereço: ");
                        while (endereco == null)
                        {
                            endereco = Console.ReadLine();
                            if (string.IsNullOrEmpty(endereco))
                            {
                                endereco = null;
                            }
                        }

                        Console.WriteLine("CPF: ");
                        while (cpf == null || !cpf.All(char.IsDigit))
                        {
                            Regex regex = new Regex(@"^([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})$");
                            cpf = Console.ReadLine();
                            Match match = regex.Match(cpf);
                            if (string.IsNullOrEmpty(cpf) || !match.Success)
                            {
                                cpf = null;
                                Console.WriteLine("Escreva um formato de CPF valido");
                            }
                        }

                        Console.WriteLine("Telefone: ");
                        while (telefone == null || !telefone.All(char.IsDigit))
                        {
                            Regex regex = new Regex(@"(?:(^\+\d{2})?)(?:([1-9]{2})|([0-9]{3})?)(\d{4,5})(\d{4})");
                            telefone = Console.ReadLine();
                            Match match = regex.Match(telefone);
                            if (string.IsNullOrEmpty(telefone) || !match.Success)
                            {
                                telefone = null;
                                Console.WriteLine("Digite um formato de telefone válido");
                            }
                        }

                        Console.WriteLine("Data de nascimnto: (dd/mm/yyyy)");
                        DateTime dataNascimento;

                        while(!DateTime.TryParse(Console.ReadLine(), out dataNascimento))
                        {
                            Console.WriteLine("Formato invalido, insira novamente (dd/mm/yyyy)");
                        }

                        Cliente novoCliente = new Cliente
                        {
                            id = clientes.Count + 1, 
                            nome = nome,
                            cpf = cpf,
                            email = email,
                            telefone = telefone,
                            dataNascimento = dataNascimento,
                            endereco = endereco
                        };

                        clientes.Add(novoCliente);

                        var clienteFiltrado = clientes.Where(n =>  n.nome == novoCliente.nome).ToList();

                        foreach(var cliente in clienteFiltrado)
                        {
                            Console.WriteLine(cliente);
                        }
                        Console.WriteLine("Cliente adicionado com sucesso");
                        break;

                    case "2":
                        Console.WriteLine("Digite o nome do cliente que deseja editar");

                        var consultaEditar = Console.ReadLine();
                        var editClient = clientes.Where(n =>  n.nome.Equals(consultaEditar)).FirstOrDefault();

                        if(editClient != null)
                        {
                            Console.WriteLine($"Nome: {editClient.nome}");
                            Console.WriteLine($"E-mail: {editClient.email}");
                            Console.WriteLine($"Endereço: {editClient.endereco}");
                            Console.WriteLine($"CPF: {editClient.cpf}");
                            Console.WriteLine($"Telefone: {editClient.telefone}");
                            Console.WriteLine($"Data de nascimnto: {editClient.dataNascimento}");

                            string editNome = null;
                            string editEmail = null;
                            string editEndereco = null;
                            string editcpf = null;
                            string editTelefone = null;
                            Console.WriteLine("Digite o nome: ");
                            while (true)
                            {
                                editNome = Console.ReadLine();
                                if (editNome != "" && editNome.All(c => char.IsLetter(c) || c == ' '))
                                {
                                    editClient.nome = editNome;
                                    break;
                                }
                                if (string.IsNullOrEmpty(editNome))
                                {
                                    break;
                                }
                                else
                                {
                                    editNome = null;
                                    Console.WriteLine("Use apenas letras!!.");
                                }
                            }

                            Console.WriteLine("Digite o E-mail: ");
                            while (true)
                            {
                                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                                editEmail = Console.ReadLine();
                                Match match = regex.Match(editEmail);

                                if (string.IsNullOrEmpty(editEmail))
                                {
                                    break;
                                }
                                if (editEmail != "" && match.Success)
                                {
                                    editClient.email = editEmail;
                                    break;
                                }
                                else
                                {
                                    editEmail = null;
                                    Console.WriteLine("Digite um email valido!!.");
                                }
                            }

                            Console.WriteLine("Digite o Endereço: ");
                            while (true)
                            {
                                editEndereco = Console.ReadLine();

                                if (string.IsNullOrEmpty(editEndereco))
                                {
                                    break;
                                }
                                if (editEndereco != "")
                                {
                                    editClient.endereco = editEndereco;
                                    break;
                                }
                                else
                                {
                                    editEndereco = null;
                                    Console.WriteLine("Digite um endereço valido!!.");
                                }
                            }

                            Console.WriteLine("Digite o CPF: ");
                            while (true)
                            {
                                Regex regex = new Regex(@"^([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})$");
                                editcpf = Console.ReadLine();
                                Match match = regex.Match(editcpf);
                                if (string.IsNullOrEmpty(editcpf))
                                {
                                    break;
                                }
                                else if (editcpf != "" && match.Success)
                                {
                                    editClient.cpf = editcpf;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("CPF inválido. Digite novamente ou pressione Enter para manter o atual.");
                                }
                            }

                            Console.WriteLine("Digite o telefone [(XX) XXXX-XXXX]: ");
                            while (true)
                            {
                                Regex regex = new Regex(@"^\([1-9]{2}\)\s(?:[2-8]|9[0-9])[0-9]{3}\-[0-9]{4}$");
                                editTelefone = Console.ReadLine();
                                Match match = regex.Match(editTelefone);

                                if (string.IsNullOrEmpty(editTelefone))
                                {
                                    break;
                                }
                                if (editTelefone != "" && match.Success)
                                {
                                    editClient.telefone = editTelefone;
                                    break;
                                }
                                else
                                {
                                    editTelefone = null;
                                    Console.WriteLine("Insira o telefone no formato valido.");
                                }
                            }

                            DateTime novaDataNasc = editClient.dataNascimento;

                            Console.WriteLine("Digite a data de nascimento (dd/mm/yyyy): ");

                            string input = Console.ReadLine();

                            if (!string.IsNullOrEmpty(input))
                            {
                                while (!DateTime.TryParse(input, out novaDataNasc))
                                {
                                    Console.WriteLine("Formato inválido. Insira novamente (dd/mm/yyyy)");
                                    input = Console.ReadLine();

                                    if (string.IsNullOrEmpty(input))
                                    {
                                        novaDataNasc = editClient.dataNascimento;
                                        break;
                                    }
                                }
                            }

                            editClient.dataNascimento = novaDataNasc;

                            clienteFiltrado = clientes.Where(n => n.nome == editClient.nome).ToList();

                            foreach (var cliente in clienteFiltrado)
                            {
                                Console.WriteLine(cliente);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nUsuário não encontrado!!.\n");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Digite o nome do cliente que deseja excluir");

                        var consultaExcluir = Console.ReadLine();
                        var deletClient = clientes.Where(n => n.nome.Equals(consultaExcluir)).FirstOrDefault();

                        if (deletClient != null)
                        {
                            clientes.Remove(deletClient);
                            Console.WriteLine("\nUsuário removido!!.\n");
                        }
                        else
                        {
                            Console.WriteLine("\nUsuário não encontrado!!.\n");
                        }
                        break;

                    case "4":
                        foreach (var cliente in clientes)
                        {
                            Console.WriteLine(cliente);
                        }
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
