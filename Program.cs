using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Proje_1._2
{
    internal class Program
    {

        class Neuron
        {
            public double weight1;
            public double weight2;

            public Neuron()
            {            
                Random rnd = new Random();
                weight1 = rnd.NextDouble();
                weight2 = rnd.NextDouble();
                   
            }
        }

        static void Main(string[] args)
        {

            Neuron n = new Neuron();

            double[][] veriseti = new double[21][];

            veriseti[0] = new double[3] { 7.6, 11, 77 };
            veriseti[1] = new double[3] { 8, 10, 70 };
            veriseti[2] = new double[3] { 6.6, 8, 55 };
            veriseti[3] = new double[3] { 8.4, 10, 78 };
            veriseti[4] = new double[3] { 8.8, 12, 95 };
            veriseti[5] = new double[3] { 7.2, 10, 67 };
            veriseti[6] = new double[3] { 8.1, 11, 80 };

            veriseti[7] = new double[3] { 9.5, 9, 87 };
            veriseti[8] = new double[3] { 7.3, 9, 60 };
            veriseti[9] = new double[3] { 8.9, 11, 88 };
            veriseti[10] = new double[3] { 7.5, 11, 72 };
            veriseti[11] = new double[3] { 7.6, 9, 58 };
            veriseti[12] = new double[3] { 7.9, 10, 70 };
            veriseti[13] = new double[3] { 8, 10, 76 };

            veriseti[14] = new double[3] { 7.2, 9, 58 };
            veriseti[15] = new double[3] { 8.8, 10, 81 };
            veriseti[16] = new double[3] { 7.6, 11, 74 };
            veriseti[17] = new double[3] { 7.5, 10, 67 };
            veriseti[18] = new double[3] { 9, 10, 82 };
            veriseti[19] = new double[3] { 7.7, 9, 62 };
            veriseti[20] = new double[3] { 8.1, 11, 82 };

            double[][] veriseti2 = new double[5][];

            veriseti2[0] = new double[3] { 5.4, 6, 67};
            veriseti2[1] = new double[3] { 8.1, 11, 81};
            veriseti2[2] = new double[3] { 9.5, 10, 95};
            veriseti2[3] = new double[3] { 4.1, 3, 37};
            veriseti2[4] = new double[3] { 3.5, 4, 74};


            // B.1 - Veri setindeki değerlerin istenilen değerlere bölünüp hedef veri setinin oluşturulması.
            double[][] targetList = UpdateDataSet(veriseti);

            // B.2 - Nöronun öğrenme katsayısı 0.5, devir sayısı 10 olacağı şekilde eğitilip, ağırlıkların güncellenmesi.
            NeuronOperation2(n,targetList, 0.05, 10);

            // B.3 - Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double [] output_table = NeuronOperation(n, targetList);

            Console.WriteLine("B Maddesi");
            Console.WriteLine();
            Console.WriteLine("Çıktı".PadRight(6) + " - " + "Hedef");
            for (int i = 0; i < output_table.Length; i++)
            {
                output_table[i] = Math.Round(output_table[i], 5); // 5 basamağa sınırlama
                Console.WriteLine(output_table[i].ToString().PadRight(6) + " - " + targetList[i][2]);
            }
            Console.WriteLine();

            // B.4 - Çıktılarla hedef verilerin karşılaştırılmasından sonra MSE değerinin hesaplanması.
            double mse = CalculateMeanSquaredError(targetList, output_table);
            Console.WriteLine("MSE: " + mse);
            Console.WriteLine();

            // C.1 - Beş girdili yeni veri setinin istenilen değerlere bölünüp hedef veri setinin oluşturulması.
            double[][] targetList2 = UpdateDataSet(veriseti2);

            // C.2 - Eğitilmiş nöronun 5 girdili yeni veri seti üzerinde işletilip çıktıların hesaplanması.
            double[] output_table2 = NeuronOperation(n, targetList2);

            Console.WriteLine("C Maddesi");
            Console.WriteLine();
            Console.WriteLine("Çıktı".PadRight(6) + " - " + "Hedef");
            for (int i = 0; i < output_table2.Length; i++)
            {
                output_table2[i] = Math.Round(output_table2[i], 5); // 5 basamağa sınırlama
                Console.WriteLine(output_table2[i].ToString().PadRight(6) + " - " + targetList2[i][2]);
            }
            Console.WriteLine();

            Console.WriteLine("D.1 Deneyi");
            Console.WriteLine();

            // D.1.1 - Öğrenme katsayısı = 0.01, Devir sayısı = 10
            n.weight1 = 0.773660133;
            n.weight2 = 0.379817208;

            NeuronOperation2(n, targetList, 0.01, 10);                                            // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList1 = NeuronOperation(n, targetList);                                // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse1 = CalculateMeanSquaredError(targetList, outputList1);
            Console.WriteLine("Öğrenme Katsayısı:  0.01, Devir Sayısı: 10  için MSE: " + mse1);
            Console.WriteLine();

            // D.1.2 - Öğrenme katsayısı = 0.025, Devir sayısı = 10
            n.weight1 = 0.773660133;
            n.weight2 = 0.379817208;

            NeuronOperation2(n, targetList, 0.025, 10);                                           // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList2 = NeuronOperation(n, targetList);                                // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse2 = CalculateMeanSquaredError(targetList, outputList2);
            Console.WriteLine("Öğrenme Katsayısı: 0.025, Devir Sayısı: 10  için MSE: " + mse2);
            Console.WriteLine();

            // D.1.3 - Öğrenme katsayısı = 0.05, Devir sayısı = 10
            n.weight1 = 0.773660133;
            n.weight2 = 0.379817208;

            NeuronOperation2(n, targetList, 0.05, 10);                                            // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList3 = NeuronOperation(n, targetList);                                // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse3 = CalculateMeanSquaredError(targetList, outputList3);
            Console.WriteLine("Öğrenme Katsayısı:  0.05, Devir Sayısı: 10  için MSE: " + mse3);
            Console.WriteLine();

            // D.1.4 - Öğrenme katsayısı = 0.01, Devir sayısı = 50
            n.weight1 = 0.773660133;
            n.weight2 = 0.379817208;

            NeuronOperation2(n, targetList, 0.01, 50);                                            // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList4 = NeuronOperation(n, targetList);                                // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse4 = CalculateMeanSquaredError(targetList, outputList4);
            Console.WriteLine("Öğrenme Katsayısı:  0.01, Devir Sayısı: 50  için MSE: " + mse4);
            Console.WriteLine();

            // D.1.5 - Öğrenme katsayısı = 0.025, Devir sayısı = 50
            n.weight1 = 0.773660133;
            n.weight2 = 0.379817208;

            NeuronOperation2(n, targetList, 0.025, 50);                                           // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList5 = NeuronOperation(n, targetList);                                // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse5 = CalculateMeanSquaredError(targetList, outputList5);
            Console.WriteLine("Öğrenme Katsayısı: 0.025, Devir Sayısı: 50  için MSE: " + mse5);
            Console.WriteLine();

            // D.1.6 - Öğrenme katsayısı = 0.05, Devir sayısı = 50
            n.weight1 = 0.773660133;
            n.weight2 = 0.379817208;

            NeuronOperation2(n, targetList, 0.05, 50);                                            // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList6 = NeuronOperation(n, targetList);                                // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse6 = CalculateMeanSquaredError(targetList, outputList6);
            Console.WriteLine("Öğrenme Katsayısı:  0.05, Devir Sayısı: 50  için MSE: " + mse6);
            Console.WriteLine();

            // D.1.7 - Öğrenme katsayısı = 0.01, Devir sayısı = 100
            n.weight1 = 0.773660133;
            n.weight2 = 0.379817208;

            NeuronOperation2(n, targetList, 0.01, 100);                                           // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList7 = NeuronOperation(n, targetList);                                // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse7 = CalculateMeanSquaredError(targetList, outputList7);
            Console.WriteLine("Öğrenme Katsayısı:  0.01, Devir Sayısı: 100 için MSE: " + mse7);
            Console.WriteLine();

            // D.1.8 - Öğrenme katsayısı = 0.025, Devir sayısı = 100
            n.weight1 = 0.773660133;
            n.weight2 = 0.379817208;

            NeuronOperation2(n, targetList, 0.025, 100);                                          // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList8 = NeuronOperation(n, targetList);                                // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse8 = CalculateMeanSquaredError(targetList, outputList8);
            Console.WriteLine("Öğrenme Katsayısı: 0.025, Devir Sayısı: 100 için MSE: " + mse8);
            Console.WriteLine();

            // D.1.9 - Öğrenme katsayısı = 0.05, Devir sayısı = 100
            n.weight1 = 0.773660133;
            n.weight2 = 0.379817208;

            NeuronOperation2(n, targetList, 0.05, 100);                                           // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList9 = NeuronOperation(n, targetList);                                // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse9 = CalculateMeanSquaredError(targetList, outputList9);
            Console.WriteLine("Öğrenme Katsayısı:  0.05, Devir Sayısı: 100 için MSE: " + mse9);
            Console.WriteLine();

            Console.WriteLine("D.2 Deneyi");
            Console.WriteLine();

            // D.2.1 - Öğrenme katsayısı = 0.01, Devir sayısı = 10
            n.weight1 = 0.513213219;
            n.weight2 = 0.812053481;

            NeuronOperation2(n, targetList, 0.01, 10);                                            // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList11 = NeuronOperation(n, targetList);                               // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse11 = CalculateMeanSquaredError(targetList, outputList11);
            Console.WriteLine("Öğrenme Katsayısı:  0.01, Devir Sayısı: 10  için MSE: " + mse11);
            Console.WriteLine();

            // D.2.2 - Öğrenme katsayısı = 0.025, Devir sayısı = 10
            n.weight1 = 0.513213219;
            n.weight2 = 0.812053481;

            NeuronOperation2(n, targetList, 0.025, 10);                                           // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList12 = NeuronOperation(n, targetList);                               // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse12 = CalculateMeanSquaredError(targetList, outputList12);
            Console.WriteLine("Öğrenme Katsayısı: 0.025, Devir Sayısı: 10  için MSE: " + mse12);
            Console.WriteLine();

            // D.2.3 - Öğrenme katsayısı = 0.05, Devir sayısı = 10
            n.weight1 = 0.513213219;
            n.weight2 = 0.812053481;

            NeuronOperation2(n, targetList, 0.05, 10);                                            // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList13 = NeuronOperation(n, targetList);                               // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse13 = CalculateMeanSquaredError(targetList, outputList13);
            Console.WriteLine("Öğrenme Katsayısı:  0.05, Devir Sayısı: 10  için MSE: " + mse13);
            Console.WriteLine();

            // D.2.4 - Öğrenme katsayısı = 0.01, Devir sayısı = 50
            n.weight1 = 0.513213219;
            n.weight2 = 0.812053481;

            NeuronOperation2(n, targetList, 0.01, 50);                                            // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList14 = NeuronOperation(n, targetList);                               // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse14 = CalculateMeanSquaredError(targetList, outputList14);
            Console.WriteLine("Öğrenme Katsayısı:  0.01, Devir Sayısı: 50  için MSE: " + mse14);
            Console.WriteLine();

            // D.2.5 - Öğrenme katsayısı = 0.025, Devir sayısı = 50
            n.weight1 = 0.513213219;
            n.weight2 = 0.812053481;

            NeuronOperation2(n, targetList, 0.025, 50);                                           // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList15 = NeuronOperation(n, targetList);                               // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse15 = CalculateMeanSquaredError(targetList, outputList15);
            Console.WriteLine("Öğrenme Katsayısı: 0.025, Devir Sayısı: 50  için MSE: " + mse15);
            Console.WriteLine();

            // D.2.6 - Öğrenme katsayısı = 0.05, Devir sayısı = 50
            n.weight1 = 0.513213219;
            n.weight2 = 0.812053481;

            NeuronOperation2(n, targetList, 0.05, 50);                                            // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList16 = NeuronOperation(n, targetList);                               // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse16 = CalculateMeanSquaredError(targetList, outputList16);
            Console.WriteLine("Öğrenme Katsayısı:  0.05, Devir Sayısı: 50  için MSE: " + mse16);
            Console.WriteLine();

            // D.2.7 - Öğrenme katsayısı = 0.01, Devir sayısı = 100
            n.weight1 = 0.513213219;
            n.weight2 = 0.812053481;

            NeuronOperation2(n, targetList, 0.01, 100);                                           // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList17 = NeuronOperation(n, targetList);                               // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse17 = CalculateMeanSquaredError(targetList, outputList17);
            Console.WriteLine("Öğrenme Katsayısı:  0.01, Devir Sayısı: 100 için MSE: " + mse17);
            Console.WriteLine();

            // D.2.8 - Öğrenme katsayısı = 0.025, Devir sayısı = 100
            n.weight1 = 0.513213219;
            n.weight2 = 0.812053481;

            NeuronOperation2(n, targetList, 0.025, 100);                                          // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList18 = NeuronOperation(n, targetList);                               // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse18 = CalculateMeanSquaredError(targetList, outputList18);
            Console.WriteLine("Öğrenme Katsayısı: 0.025, Devir Sayısı: 100 için MSE: " + mse18);
            Console.WriteLine();

            // D.2.9 - Öğrenme katsayısı = 0.05, Devir sayısı = 100
            n.weight1 = 0.513213219;
            n.weight2 = 0.812053481;

            NeuronOperation2(n, targetList, 0.05, 100);                                           // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList19 = NeuronOperation(n, targetList);                               // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse19 = CalculateMeanSquaredError(targetList, outputList19);
            Console.WriteLine("Öğrenme Katsayısı:  0.05, Devir Sayısı: 100 için MSE: " + mse19);
            Console.WriteLine();

            Console.WriteLine("D.3 Deneyi");
            Console.WriteLine();

            // D.3.1 - Öğrenme katsayısı = 0.01, Devir sayısı = 10
            n.weight1 = 0.971236712;
            n.weight2 = 0.168234976;

            NeuronOperation2(n, targetList, 0.01, 10);                                            // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList21 = NeuronOperation(n, targetList);                               // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse21 = CalculateMeanSquaredError(targetList, outputList21);
            Console.WriteLine("Öğrenme Katsayısı:  0.01, Devir Sayısı: 10  için MSE: " + mse21);
            Console.WriteLine();

            // D.3.2 - Öğrenme katsayısı = 0.025, Devir sayısı = 10
            n.weight1 = 0.971236712;
            n.weight2 = 0.168234976;

            NeuronOperation2(n, targetList, 0.025, 10);                                           // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList22 = NeuronOperation(n, targetList);                               // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse22 = CalculateMeanSquaredError(targetList, outputList22);
            Console.WriteLine("Öğrenme Katsayısı: 0.025, Devir Sayısı: 10  için MSE: " + mse22);
            Console.WriteLine();

            // D.3.3 - Öğrenme katsayısı = 0.05, Devir sayısı = 10
            n.weight1 = 0.971236712;
            n.weight2 = 0.168234976;

            NeuronOperation2(n, targetList, 0.05, 10);                                            // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList23 = NeuronOperation(n, targetList);                               // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse23 = CalculateMeanSquaredError(targetList, outputList23);
            Console.WriteLine("Öğrenme Katsayısı:  0.05, Devir Sayısı: 10  için MSE: " + mse23);
            Console.WriteLine();

            // D.3.4 - Öğrenme katsayısı = 0.01, Devir sayısı = 50
            n.weight1 = 0.971236712;
            n.weight2 = 0.168234976;

            NeuronOperation2(n, targetList, 0.01, 50);                                            // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList24 = NeuronOperation(n, targetList);                               // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse24 = CalculateMeanSquaredError(targetList, outputList24);
            Console.WriteLine("Öğrenme Katsayısı:  0.01, Devir Sayısı: 50  için MSE: " + mse24);
            Console.WriteLine();

            // D.3.5 - Öğrenme katsayısı = 0.025, Devir sayısı = 50
            n.weight1 = 0.971236712;
            n.weight2 = 0.168234976;

            NeuronOperation2(n, targetList, 0.025, 50);                                           // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList25 = NeuronOperation(n, targetList);                               // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse25 = CalculateMeanSquaredError(targetList, outputList25);
            Console.WriteLine("Öğrenme Katsayısı: 0.025, Devir Sayısı: 50  için MSE: " + mse25);
            Console.WriteLine();

            // D.3.6 - Öğrenme katsayısı = 0.05, Devir sayısı = 50
            n.weight1 = 0.971236712;
            n.weight2 = 0.168234976;

            NeuronOperation2(n, targetList, 0.05, 50);                                            // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList26 = NeuronOperation(n, targetList);                               // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse26 = CalculateMeanSquaredError(targetList, outputList26);
            Console.WriteLine("Öğrenme Katsayısı:  0.05, Devir Sayısı: 50  için MSE: " + mse26);
            Console.WriteLine();

            // D.3.7 - Öğrenme katsayısı = 0.01, Devir sayısı = 100
            n.weight1 = 0.971236712;
            n.weight2 = 0.168234976;

            NeuronOperation2(n, targetList, 0.01, 100);                                           // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList27 = NeuronOperation(n, targetList);                               // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse27 = CalculateMeanSquaredError(targetList, outputList27);
            Console.WriteLine("Öğrenme Katsayısı:  0.01, Devir Sayısı: 100 için MSE: " + mse27);
            Console.WriteLine();

            // D.3.8 - Öğrenme katsayısı = 0.025, Devir sayısı = 100
            n.weight1 = 0.971236712;
            n.weight2 = 0.168234976;

            NeuronOperation2(n, targetList, 0.025, 100);                                          // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList28 = NeuronOperation(n, targetList);                               // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse28 = CalculateMeanSquaredError(targetList, outputList28);
            Console.WriteLine("Öğrenme Katsayısı: 0.025, Devir Sayısı: 100 için MSE: " + mse28);
            Console.WriteLine();

            // D.3.9 - Öğrenme katsayısı = 0.05, Devir sayısı = 100
            n.weight1 = 0.971236712;
            n.weight2 = 0.168234976;

            NeuronOperation2(n, targetList, 0.05, 100);                                           // Verilen parametrelerle nöronun eğitilmesi ve ağırlıkların güncellenmesi.
            double[] outputList29 = NeuronOperation(n, targetList);                               // Eğitilmiş nöronu tekrar ağa vererek çıktıların hesaplanması.
            double mse29 = CalculateMeanSquaredError(targetList, outputList29);
            Console.WriteLine("Öğrenme Katsayısı:  0.05, Devir Sayısı: 100 için MSE: " + mse29);
            Console.WriteLine();

            Console.Read();
        }

        // Ağırlıkları değiştirmeden çıktıları hesaplayan fonksiyon
        static double[] NeuronOperation(Neuron n, double[][] veriseti)
        {
            double[] resultList = new double[veriseti.Length];
            double output;

            for (int i = 0; i < veriseti.Length; i++)
            {
                output = (n.weight1 * veriseti[i][0]) + (n.weight2 * veriseti[i][1]);
                resultList[i] = output;
            }

            return resultList;
        }

        // Hesaplamaları yapıp ağırlıkları güncelleyen fonksiyon
        static void NeuronOperation2(Neuron n, double[][] targetList, double ogrenme_katsayisi, int epoch)
        {
            double[] outputList = new double[targetList.Length];
            double output;

            for (int i = 0; i < epoch; i++)
            {
                for (int j = 0; j < targetList.Length; j++)
                {
                    output = (n.weight1 * targetList[j][0]) + (n.weight2 * targetList[j][1]);
                    outputList[j] = output;

                    n.weight1 = n.weight1 + ogrenme_katsayisi * (targetList[j][2] - outputList[j]) * targetList[j][0];
                    n.weight2 = n.weight2 + ogrenme_katsayisi * (targetList[j][2] - outputList[j]) * targetList[j][1];
                }
            }
        }

        // Veri setini güncelleyen fonksiyon
        static double[][] UpdateDataSet(double[][] veriseti)
        {
            double[][] updatedList = new double[veriseti.Length][];

            for (int i = 0; i < veriseti.Length;i++)
            {
                updatedList[i] = new double[3];
                updatedList[i][0] = veriseti[i][0] / 10;
                updatedList[i][1] = veriseti[i][1] / 15;
                updatedList[i][2] = veriseti[i][2] / 100;
            }

            return updatedList;
        }

        // MSE hesaplayan fonksiyon
        static double CalculateMeanSquaredError(double[][] actual, double[] predicted)
        {
            if (actual.Length != predicted.Length)
            {
                throw new ArgumentException("Hata, girdi listeleri aynı uzunluğa sahip olmalıdırlar.");
            }

            double sumOfSquaredErrors = 0.0;

            for (int i = 0; i < actual.Length; i++)
            {
                double error = actual[i][2] - predicted[i];
                sumOfSquaredErrors += error * error;
            }

            double mse = sumOfSquaredErrors / actual.Length;

            return mse;
        }
    }
}
