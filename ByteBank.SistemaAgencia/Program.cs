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
            object conta = new ContaCorrente(847, 8475531);

            Console.WriteLine("Resultado " + conta.ToString());
            Console.ReadLine();
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
