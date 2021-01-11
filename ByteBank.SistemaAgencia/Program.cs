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
            string url = "pagina?argumentos";

            Console.WriteLine(url);

            string substring = url.Substring(7);

            Console.WriteLine(substring);

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
