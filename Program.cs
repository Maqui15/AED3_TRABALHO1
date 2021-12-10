using System;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace CSVReader
{
    class Program
    {

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            string caminho = "DOCENTES_NORTE_200milLinhas_piorCaso.csv";
            long tamanho = File.ReadLines(caminho).Count();
            int[] idades = new int[tamanho];

            stopwatch.Start();
            // calculo da busca
            using (var reader = new StreamReader(caminho))
            {
                for (int i = 0; i < tamanho; i++)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    idades[i] = int.Parse(values[5]);
                }
            }

            Console.WriteLine("tempo de execução total do da busca dos arquivos é: | "+stopwatch.Elapsed+"!");
            stopwatch.Restart();

            int index = 0;

            // código da ordenação
            while (index < tamanho)
            {
                if (index == 0)
                {
                    index++;
                }

                if (idades[index] >= idades[index - 1])
                {
                    index++;
                }
                else
                {
                    int temp = 0;
                    temp = idades[index];
                    idades[index] = idades[index - 1];
                    idades[index - 1] = temp;
                    index--;
                }
            }

             Console.WriteLine("tempo de execução total da ordenação do aqurivo é: | "+stopwatch.Elapsed+"!");
             stopwatch.Restart();

            // calculo da média
            float med = 0;
            for (int i = 0; i < tamanho; i++)
            {
                med += idades[i];
            }

            float somaTotal = med / tamanho;
            Console.WriteLine("média das idades dos docentes do Norte é igual a: " + somaTotal.ToString(".0000"));

            stopwatch.Stop();
            Console.WriteLine("tempo de execução total da soma da média é: | "+stopwatch.Elapsed+"!");
        }
    }
}

// Notação big O é 3N

// caso médio ordenação e busca
// 1º teste
// tempo de execução total do da busca dos arquivos é: | 00:00:01.1327201!
// tempo de execução total da ordenação do aqurivo é: | 00:02:41.5185286!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0017572!
// 2º teste
// tempo de execução total do da busca dos arquivos é: | 00:00:01.1429720!
// tempo de execução total da ordenação do aqurivo é: | 00:02:43.1571047!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0020259!
// 3º teste
// tempo de execução total do da busca dos arquivos é: | 00:00:01.1299451!
// tempo de execução total da ordenação do aqurivo é: | 00:02:38.0248254!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0019114!
// 4º teste
// tempo de execução total do da busca dos arquivos é: | 00:00:01.1397753!
// tempo de execução total da ordenação do aqurivo é: | 00:02:43.5435272!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0016745!
// 5º teste
// tempo de execução total do da busca dos arquivos é: | 00:00:01.1522118!
// tempo de execução total da ordenação do aqurivo é: | 00:02:40.4765894!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0016510!
// 6º teste
// tempo de execução total do da busca dos arquivos é: | 00:00:01.1229942!
// tempo de execução total da ordenação do aqurivo é: | 00:02:42.4293882!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0018441!
// 7º
// tempo de execução total do da busca dos arquivos é: | 00:00:01.2235859!
// tempo de execução total da ordenação do aqurivo é: | 00:02:46.3936742!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0016178!
// 8º teste
// tempo de execução total do da busca dos arquivos é: | 00:00:01.1278403!
// tempo de execução total da ordenação do aqurivo é: | 00:02:52.3346437!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0054743!
// 9º teste
// tempo de execução total do da busca dos arquivos é: | 00:00:01.3973198!
// tempo de execução total da ordenação do aqurivo é: | 00:03:07.2083919!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0074402!
// 10º teste
// tempo de execução total do da busca dos arquivos é: | 00:00:01.9227257!
// tempo de execução total da ordenação do aqurivo é: | 00:02:59.3524947!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0019762!

// melhor caso ordenação e busca
// 1º teste
// tempo de execução total do da busca dos arquivos é: | 00:00:01.3868744!
// tempo de execução total da ordenação do aqurivo é: | 00:00:00.0016200!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0020771!
// 2º teste
// tempo de execução total do da busca dos arquivos é: | 00:00:01.4308592!
// tempo de execução total da ordenação do aqurivo é: | 00:00:00.0022729!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0032419!
// 3º teste
// tempo de execução total do da busca dos arquivos é: | 00:00:01.1011297!
// tempo de execução total da ordenação do aqurivo é: | 00:00:00.0016129!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0019117!
// 4º teste
// tempo de execução total do da busca dos arquivos é: | 00:00:01.1469882!
// tempo de execução total da ordenação do aqurivo é: | 00:00:00.0016358!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0017914!
// 5º teste
// tempo de execução total do da busca dos arquivos é: | 00:00:01.1269849!
// tempo de execução total da ordenação do aqurivo é: | 00:00:00.0015499!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0018520!
// 6º teste
// tempo de execução total do da busca dos arquivos é: | 00:00:01.1773297!
// tempo de execução total da ordenação do aqurivo é: | 00:00:00.0016029!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0018126!
// 7º teste
// tempo de execução total do da busca dos arquivos é: | 00:00:01.1038300!
// tempo de execução total da ordenação do aqurivo é: | 00:00:00.0016305!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0021343!
// 8º teste
// tempo de execução total do da busca dos arquivos é: | 00:00:01.2521490!
// tempo de execução total da ordenação do aqurivo é: | 00:00:00.0016479!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0018124!
// 9º teste
// tempo de execução total do da busca dos arquivos é: | 00:00:01.1373406!
// tempo de execução total da ordenação do aqurivo é: | 00:00:00.0016152!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0017540!
// 10º teste
// tempo de execução total do da busca dos arquivos é: | 00:00:01.1348309!
// tempo de execução total da ordenação do aqurivo é: | 00:00:00.0016239!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0019699!

//pior caso ordenação e busca
// 1º teste
// tempo de execução total do da busca dos arquivos é: | 00:00:01.3927643!
// tempo de execução total da ordenação do aqurivo é: | 00:05:45.7979604!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0026092!
// 2º teste
// tempo de execução total do da busca dos arquivos é: | 00:00:01.2294295!
// tempo de execução total da ordenação do aqurivo é: | 00:06:15.1631287!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0034250!
// 3º teste
// tempo de execução total do da busca dos arquivos é: | 00:00:01.4161455!
// tempo de execução total da ordenação do aqurivo é: | 00:05:22.0167597!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0019005!
// 4º teste 
// tempo de execução total do da busca dos arquivos é: | 00:00:01.1249162!
// tempo de execução total da ordenação do aqurivo é: | 00:05:33.2149404!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0018480!
// 5º teste 
// tempo de execução total do da busca dos arquivos é: | 00:00:01.1303593!
// tempo de execução total da ordenação do aqurivo é: | 00:05:45.6357323!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0134303!
//6º teste
// tempo de execução total do da busca dos arquivos é: | 00:00:01.5700629!
// tempo de execução total da ordenação do aqurivo é: | 00:05:32.6573240!
// média das idades dos docentes do Norte é igual a: 38,5314
// tempo de execução total da soma da média é: | 00:00:00.0022400!