using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
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
            Console.ReadLine();
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
