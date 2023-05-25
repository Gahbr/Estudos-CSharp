﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_4_Estacionamento
{
    internal class Persistencia
    {
        readonly static string entradaFilePath = "veiculosEntrada.dat";
        readonly static string saidaFilePath = "veiculosSaida.dat";

        public static void LerArquivoEntrada(List<Veiculo> listaVeiculos )
        {
            if (File.Exists(entradaFilePath) && new FileInfo(entradaFilePath).Length > 0)
            {
                StreamReader leitor = new StreamReader(entradaFilePath);
                do
                {
                    string linha = leitor.ReadLine();
                    string[] vetorDados = linha.Split(";");
                    Veiculo veiculo = new(vetorDados[0], DateTime.Parse(vetorDados[1]), DateTime.Parse(vetorDados[2]));

                    listaVeiculos.Add(veiculo);

                } while (!leitor.EndOfStream);

                leitor.Close();
               
            }else
            {
                StreamWriter escritor = new StreamWriter(entradaFilePath);
                escritor.Close();
            }
        }

       public static void LerArquivosSaida(List<Veiculo> listaVeiculosSaida)
        {
            if (File.Exists(saidaFilePath) && new FileInfo(entradaFilePath).Length > 0)
            {
                StreamReader leitor = new StreamReader(saidaFilePath);
                do
                {
                    string linha = leitor.ReadLine();
                    string[] vetorDados = linha.Split(";");
                    Veiculo veiculo = new(vetorDados[0], DateTime.Parse(vetorDados[1]), DateTime.Parse(vetorDados[2]));
         

                    listaVeiculosSaida.Add(veiculo);
                  //  listBoxVeiculosSaida.Items.Add($"{veiculo.Placa};{dataEntradaFormatada};{horaEntradaFormatada};{tempoFormatado};{veiculo.ValorCobrado} {Environment.NewLine}");

                } while (!leitor.EndOfStream);

                leitor.Close();
            }
        }

        public static void GravarArquivoEntrada(Veiculo veiculo)
        {
            StreamWriter escritor = new StreamWriter(entradaFilePath, true);
            escritor.WriteLine($"{veiculo.Placa};{veiculo.DataEntrada:d};{veiculo.HoraEntrada:t}");
            escritor.Close();
        }
        public static void AtualizarArquivoEntrada(List<Veiculo> listaVeiculos)
        {
            //lendo o arquivo de entrada e atualizando
            StreamWriter atualizaArquivo = new StreamWriter(entradaFilePath, false);
            foreach (var item in listaVeiculos)
            {
                atualizaArquivo.WriteLine($"{item.Placa};{item.DataEntrada:d};{item.HoraEntrada:t}");
            }
            atualizaArquivo.Close();
        }

        public static void gravarArquivoVeiculosSaida(Veiculo veiculo)
        {
            string tempoFormatado = veiculo.TempoPermanencia.ToString(@"hh\:mm\:ss");
            string dataEntradaFormatada = veiculo.DataEntrada.ToString(@"d");
            string horaEntradaFormatada = veiculo.HoraEntrada.ToString(@"t");

            StreamWriter escritor = new StreamWriter(saidaFilePath, true);
            escritor.WriteLine($"{veiculo.Placa};{dataEntradaFormatada};{horaEntradaFormatada};{tempoFormatado};{veiculo.ValorCobrado}");
            escritor.Close();
        }
    }
}
