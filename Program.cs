using Dio.Series.Classes;
using Dio.Series.Enums;
using Dio.Series.Repositories;
using System;
using System.Linq;

namespace Dio.Series
{
    class Program
    {
        static SerieRepository _serieRepository = new SerieRepository();

        static void Main(string[] args)
        {
            ShowOptionMenu();
        }

        static void ShowOptionMenu()
        {
            Console.Write("**************   Dio Séries   *************************\n\n" +
                "1- Listar Série\n" +
                "2- Adicionar Série\n" +
                "3- Atualizar Série\n" +
                "4- Excluir Série\n" +
                "C- Limpar\n" +
                "X- Sair\n" +
                "Escolha uma opção: ");

            var option = Console.ReadLine();

            ChoiceOptionMenu(option);
        }

        static void ChoiceOptionMenu(string option)
        {
            switch (option)
            {
                case "1":
                    GetSeries();
                    break;
                case "2":
                    AddSerie();
                    break;
                case "3":
                    UpdateSerie();
                    break;
                case "4":
                    ExcludeSerie();
                    break;
                case "C":
                case "c":
                    ClearWindow();
                    break;
                case "X":
                case "x":
                    Exit();
                    break;
                default:
                    InvalidOption();
                    break;
            }
        }

        static void GetSeries()
        {
            var series = _serieRepository.GetAll();

            if (series == null || !series.Any())
                Console.WriteLine("\nNenhuma série cadastrada!\n");
            else
                foreach (var serie in series)
                    Console.Write($"\n{serie}");

            Console.WriteLine("\n\n");

            ShowOptionMenu();
        }

        static void AddSerie()
        {
            var serie = SetDataSerie(true);

            _serieRepository.Add(serie);

            Console.WriteLine("\nSérie adicionada com sucesso!\n");

            ShowOptionMenu();
        }

        static void UpdateSerie()
        {
            var serie = GetSerie();

            if (serie != null)
            {
                Console.WriteLine($"\n{serie}");
                Console.Write("\nDeseja editar os dado da série? (S/N): ");
                string option = Console.ReadLine();

                if (option == "S" || option == "s")
                {
                    serie = SetDataSerie(false);

                    _serieRepository.Update(serie.Id, serie);

                    Console.WriteLine("\nSérie atualizada com sucesso!\n");
                }
            }

            ShowOptionMenu();
        }

        static void ExcludeSerie()
        {
            var serie = GetSerie();

            if (serie != null)
            {
                Console.WriteLine($"\n{serie}");
                Console.Write("\nDeseja excluir a série? (S/N): ");
                string option = Console.ReadLine();

                if (option == "S" || option == "s")
                {
                    _serieRepository.Delete(serie.Id);

                    Console.WriteLine("\nSérie excluida com sucesso!\n");
                }
            }

            ShowOptionMenu();
        }

        static Serie SetDataSerie(bool isInsert)
        {
            foreach (var gender in Enum.GetValues(typeof(GenderEnum)))
                Console.Write($"\nID: {gender.GetHashCode()} - {gender.ToString()}");

            Console.Write("\n\nEscolha o ID de um Gênero acima: ");
            int genderId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Título da Série: ");
            string title = Console.ReadLine();

            Console.Write("Descrição da Série: ");
            string description = Console.ReadLine();

            Console.Write("Ano da Série (yyyy): ");
            int year = Convert.ToInt32(Console.ReadLine());

            if (isInsert)
                return new Serie(_serieRepository.NextId(), (GenderEnum)genderId, title, description, year);
            else
                return new Serie((GenderEnum)genderId, title, description, year);
        }

        static Serie GetSerie()
        {
            Console.Write("\nInforme o código da série: ");
            int serieId = Convert.ToInt32(Console.ReadLine());

            var serie = _serieRepository.GetById(serieId);

            if (serie == null)
                Console.WriteLine("\nSérie não encontrada!\n");

            return serie;
        }

        static void ClearWindow()
        {
            Console.Clear();

            ShowOptionMenu();
        }

        static void Exit()
        {
            Console.Write("\nDeseja sair do sistema? (S/N): ");
            string option = Console.ReadLine();

            if (option == "S" || option == "s")
                Console.WriteLine("\nSessão encerrada!\n");
            else
                ShowOptionMenu();
        }

        static void InvalidOption()
        {
            Console.WriteLine("\nOpção informada é invalida! Tente novamente....\n");

            ShowOptionMenu();
        }
    }
}
