using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes
{
    public class Cliente
    {
        public int id {  get; set; }
        public string nome {  get; set; }
        public string email { get; set; }
        public string endereco { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }
        public DateTime dataNascimento { get; set; }

        public Cliente() { }
        public Cliente(int id, string nome, string email, string endereco, string cpf, string telefone, DateTime dataNascimento)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.endereco = endereco;
            this.cpf = cpf;
            this.telefone = telefone;
            this.dataNascimento = dataNascimento;
        }

        public override string ToString()
        {
            return $"ID {id}, Nome: {nome}, Email: {email}, Endereço: {endereco}, CPF: {cpf}, Telefone: {telefone}, Data de Nascimento: {dataNascimento.Date.ToString().Substring(0, 10)}\n";
        }
    }
}
