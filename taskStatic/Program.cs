using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace taskStatic
{
    internal class Program
    {
        static double[] arraycreater()
        {

            Console.Write("Enter number of elements :  ");
            int size = Convert.ToInt32(Console.ReadLine());

            double[] element = new double[size];

            for (int i = 0; i < element.Length; i++)
            {
                Console.Write("element " + (i + 1) + " : ");
                element[i] = Convert.ToDouble(Console.ReadLine());
            }

            //sorting the array 
            Array.Sort(element);

            return element;

        }

        static double median(double[] eldataSet)
        {
            double elmedian = 0;
            int dataSetElements = eldataSet.Length;


            if (dataSetElements % 2 == 0)
            {
                elmedian = ((eldataSet[(dataSetElements / 2)] + (eldataSet[(dataSetElements / 2) - 1]))) / 2;

            }
            else
            {
                elmedian = eldataSet[dataSetElements / 2];

            }

            return elmedian;

        }

        static double mode(double[] eldataSet)
        {

            int[] elcounter = new int[eldataSet.Length];

            for (int i = 0; i < eldataSet.Length; i++)
            {
                elcounter[i] = 0;

                for (int j = 0; j < eldataSet.Length; j++)
                {

                    if (eldataSet[i] == eldataSet[j])
                    {
                        elcounter[i]++;
                    }
                }
            }

            double elmode = 0;
            int maxCount = 0;

            for (int i = 0; i < elcounter.Length; i++)
            {

                if (elcounter[i] > maxCount && elcounter[i] > 1)
                {
                    elmode = eldataSet[i];
                    maxCount = elcounter[i];
                }
            }

            return elmode;
        }

        static double range(double[] eldataSet)
        {
            double range = eldataSet.Max() - eldataSet.Min();

            return range;

        }

        static double firstQ(double[] eldataSet)
        {
            double elfirstQ = 0;

            int dataSetElements = eldataSet.Length;

            double[] elHalf = new double[eldataSet.Length / 2];
            for (int i = 0; i < elHalf.Length; i++)
            {
                elHalf[i] = eldataSet[i];
            }
            return median(elHalf);
        }

        static double lastQ(double[] eldataSet)
        {
            double elLastQ = 0;

            int dataSetElements = eldataSet.Length;
            int j = 0;

            double[] elHalf = new double[eldataSet.Length / 2];

            if (dataSetElements % 2 == 0)
            {
                for (int i = elHalf.Length; i < eldataSet.Length; i++)
                {
                    elHalf[j] = eldataSet[i];
                    j++;
                }
            }

            else
            {
                for (int i = elHalf.Length + 1; i < eldataSet.Length; i++)
                {
                    elHalf[j] = eldataSet[i];
                    j++;
                }
            }



            Array.Sort(elHalf);

            elLastQ = median(elHalf);
            return elLastQ;

        }

        static double IQR(double[] eldataSet)
        {
            return lastQ(eldataSet) - firstQ(eldataSet);

        }

        static double P90(double[] eldataSet)
        {
            double p90 = (eldataSet.Length) * 0.90;
            p90 = eldataSet[Convert.ToInt32(p90 - 1)];
            return p90;
        }

        static double[] boundaries(double[] eldataSet)
        {
            double high = lastQ(eldataSet) + (1.5 * IQR(eldataSet));

            double low = firstQ(eldataSet) - (1.5 * IQR(eldataSet));

            return new double[] { high, low };

        }

        static List<double> outOfboundaries(double[] eldataset)
        {
            List<double> list = new List<double>();

            for (int i = 0; i < eldataset.Length; i++)
            {
                if (eldataset[i] > boundaries(eldataset)[0] || eldataset[i] < boundaries(eldataset)[1])
                {
                    list.Add(eldataset[i]);
                }
            }

            return list;
        }



        static void display(double[] eldataSet)
        {
            Console.WriteLine("\n--------------------------------------------");
            Console.WriteLine("Data set = ");
            foreach (double element in eldataSet)
            {
                Console.Write(element + ",  ");
            }
            Console.WriteLine("\n--------------------------------------------");

            Console.WriteLine("\n\t __________");
            Console.WriteLine("\t | OUTPUT | ");
            Console.WriteLine("\t ----------");


            Console.WriteLine("\n  | Median = " + median(eldataSet));
            Console.WriteLine("  | Mode = " + mode(eldataSet));
            Console.WriteLine("  | Range = " + range(eldataSet));
            Console.WriteLine("  | Q1 = " + firstQ(eldataSet));
            Console.WriteLine("  | Q3 = " + lastQ(eldataSet));
            Console.WriteLine("  | P90 = " + P90(eldataSet));
            Console.WriteLine("  | IQR = " + IQR(eldataSet));

            Console.Write("  | boundaries =  ");
            foreach (double element in boundaries(eldataSet))
            {
                Console.Write(element + ",  ");
            }

            if (0 < outOfboundaries(eldataSet).Count)
            {
                Console.Write("\n  | ");

                foreach (double num in outOfboundaries(eldataSet))
                {
                    Console.Write(num + ",  ");

                }
                Console.WriteLine("Is out of boundaries \n\n\n");
            }

            else Console.WriteLine("\n  | out of boundaries = No elemnts out of boundaries\n\n\n");
        }

        static void Main(string[] args)
        {
            display(arraycreater());

        }
    }
}
