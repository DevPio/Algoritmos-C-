using System;

namespace Algoritmos
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = new int[5];
            var nomes = new string[5];
            var inteiros = new int[]{1,2,3,4 };

            Console.WriteLine(inteiros[0]);

            numeros[0] = 10;
            numeros[1] = 20;
            numeros[2] = 30;
            numeros[3] = 40;
            numeros[4] = 50;

            System.Console.WriteLine(numeros[0]);
            System.Console.WriteLine(numeros[1]);
            System.Console.WriteLine(numeros[2]);
            System.Console.WriteLine(numeros[3]);
            System.Console.WriteLine(numeros[4]);
            

         foreach (var item in numeros)
         {
             System.Console.WriteLine(item);
         }

         for (int i = 0; i < numeros.Length; i++)
         {
             System.Console.WriteLine(numeros[i]);
         }

        int search =  Program.buscaBinaria(numeros,10);

        int searchLinear = Program.BuscarLinear(numeros,10);

        System.Console.WriteLine(search);

        System.Console.WriteLine(searchLinear);

       
        Console.WriteLine("====== resultado da busca =====");
        Console.WriteLine(Program.buscaBinariaRecursive(numeros,10));
        
        var desodernados = new int[]{8,2,9,3,1};
        Console.WriteLine("====== antes da ordem =====");
        Console.WriteLine(String.Join(',',desodernados));
        var valores = Program.SortSelection(desodernados);

        Console.WriteLine("====== depois da ordem =====");
        Console.WriteLine(String.Join(',',valores));


        var itens = new int[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16};

        System.Console.WriteLine(Program.buscaBinaria(itens,14));
        System.Console.WriteLine(Program.buscaBinariaRecursive(itens,14));

        var max = itens.Length - 1;

        var min = 0;
        var elemento = 10;
        
        int metade;

        while (min <= max)
        {
             metade = (int)((min + max)/2);
             var valorPontecial = itens[metade];
           
            if (valorPontecial == elemento)
            {
                Console.WriteLine("======== Achou ==========");
                Console.WriteLine(metade);
                break;
            }else if(elemento < metade){
                max--;
            }else{
               
                min++;
            }
        }
        
        }


        public static int buscaBinaria(int[] array, int number){
            
            int min = 0;
            int max = array.Length - 1;

            int guess;
            double app;
            while (min < max)
            {
                
                 app = (min + max) / 2;
                 guess = (int)Math.Floor(app);

                 var valorPotencial = array[guess];

                 if (number == valorPotencial)
                 {
                     return guess;
                 }else if( number < valorPotencial){
                     max--;
                 }else{
                     min++;
                 }
            }


            return -1;
        }
        public static int buscaBinariaRecursive(int[] array, int target){
            return buscaBinariaRecursiveHelper(array, target, 0, array.Length - 1);
        }
        public static int buscaBinariaRecursiveHelper(int[] array, int target, int min, int max){

            if (min >= max) return -1;

            double calc = (min + max) / 2;
            int guess = (int)Math.Floor(calc);

            var valorPotencial = array[guess];

            if ( valorPotencial == target)
            {
                return guess;
            }else if(target < guess){
                return buscaBinariaRecursiveHelper(array, target, min , max -1 );
            }else{
                return buscaBinariaRecursiveHelper(array, target, min + 1 , max);
            }

            
           
        }
        public static int BuscarLinear(int[] array, int number){

            for (int i = 0; i < array.Length; i++)
                if (array[i] == number) return i;
                

            return -1;

            //melhor caso: quando o item procurado está na primeira posição executado : 1

            //pior caso: quando o elemento buscado esta na última posição executado N = length do vetor O(n)

            //caso médio: quando o elemento esta em N/2
        }



        public static int[]  SortSelection(int[] array){

            // for (int i = 0; i < array.Length; i++)
            // {
            //     for (int j = i + 1; j < array.Length; j++)
            //     {
            //         if (array[j] < array[i])
            //         {
            //             int temp = array[i];
            //             array[i] = array[j];
            //             array[j] = temp;

            //         }
            //     }
            // }

            //Melhor caso é executado N * N
            //Pior caso é executado N * N -> O(N * N)
            //Caso médio N * N
             for (int i = 0; i < array.Length; i++)
            {
                var menor = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[menor])
                    {
                       menor = j;

                    }
                }

                if (menor != i)
                {
                    var temp = array[i];
                    array[i] = array[menor];
                    array[menor] = temp;
                }
            }

            return array;
        }
    }
}
