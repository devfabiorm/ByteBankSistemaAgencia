using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;
using System.Text.RegularExpressions;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            lista.Adicionar(new ContaCorrente(874, 8745656));
            lista.Adicionar(new ContaCorrente(874, 8745655));
            lista.Adicionar(new ContaCorrente(874, 8745654));
            lista.Adicionar(new ContaCorrente(874, 8745654));
            lista.Adicionar(new ContaCorrente(874, 8745654));
            lista.Adicionar(new ContaCorrente(874, 8745654));
            lista.Adicionar(new ContaCorrente(874, 8745654));

            Console.ReadLine();
        }

        static void TestaArrayDeContaCorrente()
        {
            ContaCorrente[] contas = new ContaCorrente[]
            {
                new ContaCorrente(874, 8745656),
                new ContaCorrente(874, 8744456),
                new ContaCorrente(874, 8742135)
            };

            for (int indice = 0; indice < contas.Length; indice++)
            {
                ContaCorrente contaAtual = contas[indice];
                Console.WriteLine($"Conta {indice} {contaAtual.Numero}");
            }
        }

        static void TestaObjectMethods()
        {
            object conta = new ContaCorrente(847, 8475531);

            Console.WriteLine("Resultado " + conta.ToString());

            Cliente cliente = new Cliente();
            cliente.Nome = "Fabio";
            cliente.CPF = "123.123.123-12";
            cliente.Profissao = "Desenvolvedor";

            Cliente cliente2 = new Cliente();
            cliente2.Nome = "Fabio";
            cliente2.CPF = "123.123.123-12";
            cliente2.Profissao = "Desenvolvedor";

            if (cliente.Equals(cliente2))
            {
                Console.WriteLine("São iguais");
            }
            else
            {
                Console.WriteLine("São diferentes");
            }
        }

        static void TestaString()
        {
            //string padrao = "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
            //string padrao = "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";
            //string padrao = "[0-9]{4}[-][0-9]{4}";
            //string padrao = "[0-9]{4,5}[-][0-9]{4}";
            //string padrao = "[0-9]{4,5}[-]{0,1}[0-9]{4}";
            //string padrao = "[0-9]{4,5}-{0,1}[0-9]{4}";
            string padrao = "[0-9]{4,5}-?[0-9]{4}";

            string textoTeste = "Pode me ligar em 94546-3234";
            Match teste = Regex.Match(textoTeste, padrao);
            Console.WriteLine(teste.Value);
            Console.ReadLine();

            string urlTeste = "https://www.bytebank.com/cambio";
            Console.WriteLine(urlTeste.StartsWith("https://www.bytebank.com"));
            Console.WriteLine(urlTeste.EndsWith("cambio"));
            Console.WriteLine(urlTeste.Contains("bytebank"));
            Console.ReadLine();

            string urlParametros = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar";
            ExtratorDeArgumentosURL extrator = new ExtratorDeArgumentosURL(urlParametros);
            string valor = extrator.GetValor("MoEdaOrigem");
            string valor2 = extrator.GetValor("moedadesTino");

            Console.WriteLine("Valor de moedaOrigem: " + valor);
            Console.WriteLine("Valor de moedaDestino: " + valor2);
        }

        static void TestaDateTime()
        {
            DateTime dataFimPagamento = new DateTime(2021, 5, 9);
            DateTime dataCorrente = DateTime.Now;

            TimeSpan diferenca = TimeSpan.FromMinutes(60);

            string mensagem = "Expires in " + TimeSpanHumanizeExtensions.Humanize(diferenca);

            Console.WriteLine(mensagem);

            ContaCorrente conta = new ContaCorrente(847, 847286);
        }
    }
}
