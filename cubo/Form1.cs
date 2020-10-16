using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cubo
{
    public partial class Form1 : Form
    {

        string[,,] arbol = new string[2, 2, 100];
        string[,,] combinaciones = new string[2, 2, 100];
        int ultimo_cubo_arbol = 0;
        int ultimo_cubo_combinaciones = 0;
        string[,] cubo = new string[2, 2];
        string elemento_lista = "";


        public Form1()
        {
            InitializeComponent();
            textBox5.Text = "B";
            textBox6.Text = "3";
            textBox7.Text = "1";
            textBox8.Text = "2";
            label4.Text = "";
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            for (int i=0;i<2;i++)
            {
                for(int j=0;j<2;j++)
                {
                    for(int k=0;k<100; k++)
                    {
                        arbol[i,j,k] = "0";
                        combinaciones[i, j, k] = "0";
                    }
                }

            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            


            cubo[0,0] = textBox1.Text;
            cubo[0,1] = textBox2.Text;
            cubo[1,0] = textBox3.Text;
            cubo[1,1] = textBox4.Text;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    arbol[i, j,0] = cubo[i, j];
                    combinaciones[i, j, 0] = cubo[i, j];
                }
            }

            string elemento_lista = cubo[0, 0] + cubo[0, 1] + cubo[1, 0] + cubo[1, 1];
            listBox1.Items.Add(elemento_lista);
            listBox2.Items.Add(elemento_lista);

            int bien= fichas_correctas(cubo);
            if (bien==1)
            {
                label4.Text = "";
                elemento_lista= movimientos(cubo);
                listBox1.Items.Add(elemento_lista);
                listBox2.Items.Add(elemento_lista);
            }
            else
            {
                label4.Text = "Digitos Incorrectos";
            }
            


            

        }

        public int ultimo_cub(string[,,] arbol)
        {
            
            for (int k = 0; k < 100; k++)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if(arbol[i,j,k].Equals("0"))
                        {
                            
                            return k;
                            
                        }
                    }
                }

            }

            return 0;

        }

        public string movimientos(string[,] cubo)
        {
            ultimo_cubo_arbol = ultimo_cub(arbol);
            ultimo_cubo_combinaciones=ultimo_cub(combinaciones);
            string[,] cubo_auxiliar = new string[2, 2];
            string auxiliar;
            elemento_lista = "";
            for(int i = 0; i < 2; i++)
            {
                for(int j=0;j<2;j++)
                {
                    cubo_auxiliar[i, j] = cubo[i, j];
                }
            }



            for(int i = 0; i < 2; i++)
            {
                for(int j=0;j<2;j++)
                {
                    if (cubo_auxiliar[i, j].Equals("B"))
                    {
                        try
                        {
                            auxiliar = cubo_auxiliar[i + 1, j];
                            cubo_auxiliar[i + 1, j] = cubo_auxiliar[i, j];
                            cubo_auxiliar[i, j] = auxiliar;

                            for (int fila = 0; fila < 2; fila++)
                            {
                                for (int columna = 0; columna < 2; columna++)
                                {
                                    arbol[fila, columna,ultimo_cubo_arbol] = cubo[fila, columna];
                                }
                            }

                            ultimo_cubo_arbol += 1;

                            elemento_lista = elemento_lista + cubo_auxiliar[0, 0] + cubo_auxiliar[0, 1] + cubo_auxiliar[1, 0] + cubo_auxiliar[1, 1] + ",";
                            
                            for (int fila = 0; fila < 2; fila++)
                            {
                                for (int columna = 0; columna < 2; columna++)
                                {
                                    cubo_auxiliar[fila, columna] = cubo[fila, columna];
                                }
                            }



                        }
                        catch
                        {
                            
                        }

                        try
                        {
                            auxiliar = cubo_auxiliar[i - 1, j];
                            cubo_auxiliar[i - 1, j] = cubo_auxiliar[i, j];
                            cubo_auxiliar[i, j] = auxiliar;

                            for (int fila = 0; fila < 2; fila++)
                            {
                                for (int columna = 0; columna < 2; columna++)
                                {
                                    arbol[fila, columna, ultimo_cubo_arbol] = cubo[fila, columna];
                                }
                            }

                            ultimo_cubo_arbol += 1;

                            elemento_lista = elemento_lista + cubo_auxiliar[0, 0] + cubo_auxiliar[0, 1] + cubo_auxiliar[1, 0] + cubo_auxiliar[1, 1] + ",";

                            for (int fila = 0; fila < 2; fila++)
                            {
                                for (int columna = 0; columna < 2; columna++)
                                {
                                    cubo_auxiliar[fila, columna] = cubo[fila, columna];
                                }
                            }



                        }
                        catch
                        {

                        }

                        try
                        {
                            auxiliar = cubo_auxiliar[i , j+1];
                            cubo_auxiliar[i, j+1] = cubo_auxiliar[i, j];
                            cubo_auxiliar[i, j] = auxiliar;

                            for (int fila = 0; fila < 2; fila++)
                            {
                                for (int columna = 0; columna < 2; columna++)
                                {
                                    arbol[fila, columna, ultimo_cubo_arbol] = cubo[fila, columna];
                                }
                            }

                            ultimo_cubo_arbol += 1;

                            elemento_lista = elemento_lista + cubo_auxiliar[0, 0] + cubo_auxiliar[0, 1] + cubo_auxiliar[1, 0] + cubo_auxiliar[1, 1] + ",";

                            for (int fila = 0; fila < 2; fila++)
                            {
                                for (int columna = 0; columna < 2; columna++)
                                {
                                    cubo_auxiliar[fila, columna] = cubo[fila, columna];
                                }
                            }



                        }
                        catch
                        {

                        }

                        try
                        {
                            auxiliar = cubo_auxiliar[i , j-1];
                            cubo_auxiliar[i , j-1] = cubo_auxiliar[i, j];
                            cubo_auxiliar[i, j] = auxiliar;

                            for (int fila = 0; fila < 2; fila++)
                            {
                                for (int columna = 0; columna < 2; columna++)
                                {
                                    arbol[fila, columna, ultimo_cubo_arbol] = cubo[fila, columna];
                                }
                            }

                            ultimo_cubo_arbol += 1;

                            elemento_lista = elemento_lista + cubo_auxiliar[0, 0] + cubo_auxiliar[0, 1] + cubo_auxiliar[1, 0] + cubo_auxiliar[1, 1] + ",";

                            for (int fila = 0; fila < 2; fila++)
                            {
                                for (int columna = 0; columna < 2; columna++)
                                {
                                    cubo_auxiliar[fila, columna] = cubo[fila, columna];
                                }
                            }



                        }
                        catch
                        {

                        }

                        
                    }
                }
            }

            return elemento_lista;
            
        }

        public int fichas_correctas(string[,] cubo)
        {
            string[] fichas_correctas = new string[4];
            fichas_correctas[0] = "1";
            fichas_correctas[1] = "2";
            fichas_correctas[2] = "3";
            fichas_correctas[3] = "B";

            int aux= 0;

            foreach (string ficha in fichas_correctas)
            {
                foreach (string casilla in cubo)
                {
                    if (casilla.Equals(ficha))
                    {
                        aux =1;
                    }
                    
                }
                if(aux==0)
                {
                    
                    return 0;
                }
                aux = 0;
            }

            if(cubo[0,0].Equals(cubo[0,1]) || cubo[0, 0].Equals(cubo[1, 0]) || cubo[0, 0].Equals(cubo[1, 1]))
            {
                return 0;
            }

            if(cubo[0,1].Equals(cubo[1, 1]) || cubo[0, 1].Equals(cubo[1, 0]))
            {
                return 0;
            }

            if(cubo[1, 0].Equals(cubo[1, 1]))
            {
                return 0;
            }
            

            

           
            


            return 1;

            



        }

        public void cola()
        {
            for(int i = 0; i < 2; i++)
            {
                for(int j=0;j<2;j++)
                {
                    cubo[i, j]=arbol[i,j,0];
                }
            }

            while (true)
            {
                elemento_lista = "";
                elemento_lista = movimientos(cubo);

                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }
    }
}
