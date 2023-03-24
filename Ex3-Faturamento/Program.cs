using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Ex3_Faturamento;
class Program
{
    static void Main(string[] args)
    {
        var jsontxt = File.ReadAllText(@"json.txt");
        var newjson = JsonConvert.DeserializeObject<List<Valores>>(jsontxt);
        double menor = newjson![0].valor;
        double maior = 0.0;
        int totalDias = 0;
        int i = 0;
        double somaValor = 0;

        string str = new('=', 23);
        Console.WriteLine(str);
        Console.WriteLine("  Faturamento Mensal");
        Console.WriteLine(str);

        for (i = 0; i < 30; i++)
        {
            double valor = newjson[i].valor;

            if (valor != 0 && valor < menor)
            {
                menor = valor;
            }
            if (valor > maior)
            {
                maior = valor;
            }
            if (valor > 0)
            {
                totalDias++;
            }

            somaValor += valor;
        }

        Console.WriteLine($"O menor valor de faturamento ocorrido em um dia do mês foi de R${menor:C}.");
        Console.WriteLine($"O maior valor de faturamento ocorrido em um dia do mês foi de R${maior:C}.");

        double media = somaValor / totalDias;
        int totalDias2 = 0;
        for (i = 0; i < 30; i++)
        {
            if (newjson[i].valor > media)
            {
                totalDias2++;
            }
        }

        Console.WriteLine($"{totalDias2} dias no mês o valor de faturamento diário foi superior à média mensal.");
        Console.ReadKey();
    }
}

