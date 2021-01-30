using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BombasGasolina
{ 
    
    public partial class Bombas : Form
    {
        public Bombas()
        {
            InitializeComponent();
        }

        //Declaraçao de variaveis
        #region
        Boolean Editar = false;
        Boolean Editar2 = false;
        Boolean f = false;
        public Precos PrecosBombas;
        public QuantVal Calc;
        public QuantVal DinheiroGasto ;
        public BombasTotal[] Info = new BombasTotal[4];

        // O i determina que bomba esta a ser usada
        public int i;
        #endregion

        private void Bombas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Menu Menu1 = (Menu)this.Owner;
           

            if (i == 1)
            {
                Menu1.timer1.Enabled = true;
                Menu1.EstadoBombas[0] = false;
            }
            if (i == 2)
            {
                Menu1.timer2.Enabled = true;
                Menu1.EstadoBombas[1] = false;
            }
            if (i == 3)
            {
                Menu1.timer3.Enabled = true;
                Menu1.EstadoBombas[2] = false;
            }
            if (i == 4)
            {
                Menu1.timer4.Enabled = true;
                Menu1.EstadoBombas[3] = false;
            } 
        }

        //Buttons
        #region

        //botao de pre-pagamento 
        private void button2_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                txtPreco.Enabled = true;
                Editar = true;
                txtQuant.Enabled = false;
                Editar2 = false;
            }
           
           
        }

        // botao de encher o deposito
        private void button1_Click(object sender, EventArgs e)
        {
            if (Editar2 == false)
            {
                txtQuant.Enabled = true;
                Editar2 = true;
                txtPreco.Enabled = false;
                Editar = false;
            }
           
        }
        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (f == false)
            {
                #region


                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Tem que preencher todos os campos");
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtQuant.Text))
                    {
                        Calc.Quant = double.Parse(txtQuant.Text);
                    }

                    else if (!string.IsNullOrEmpty(txtPreco.Text))
                    {
                        Calc.Valor = double.Parse(txtPreco.Text);
                    }

                    // calcula, a partir dos valores das textboxs do menu, quando custa encher o deposito
                    if (txtQuant.Enabled == true)
                    {
                        if (string.IsNullOrEmpty(txtQuant.Text))
                        {
                            MessageBox.Show("Tem que preencher todos os campos");
                        }
                        else
                        {
                            button1.Enabled = false;
                            button2.Enabled = false;
                            txtPreco.Enabled = false;
                            txtQuant.Enabled = false;
                            btnCalc.Text = "Pagar";

                            if (comboBox1.SelectedIndex == 0)
                            {
                                txtPreco.Text = (Calc.Quant * PrecosBombas.Gas).ToString("#0.00");
                            }

                            if (comboBox1.SelectedIndex == 1)
                            {
                                txtPreco.Text = (Calc.Quant * PrecosBombas.GasPls).ToString("#0.00");
                            }

                            if (comboBox1.SelectedIndex == 2)
                            {
                                txtPreco.Text = (Calc.Quant * PrecosBombas.Gleo).ToString("#0.00");
                            }

                            if (comboBox1.SelectedIndex == 3)
                            {
                                txtPreco.Text = (Calc.Quant * PrecosBombas.GleoPls).ToString("#0.00");
                            }
                        }

                    }

                    // calcula, a partir dos valores das textbosx do menu, quanto é que pode abastecer com uma certa quantidade de dinheiro
                    if (txtPreco.Enabled == true)
                    {
                        if (string.IsNullOrEmpty(txtPreco.Text))
                        {
                            MessageBox.Show("Tem que preencher todos os campos");
                        }
                        else
                        {

                            if (comboBox1.SelectedIndex == 0)
                            {
                                txtQuant.Text = (Calc.Valor / PrecosBombas.Gas).ToString("#0.00"); ;
                            }

                            if (comboBox1.SelectedIndex == 1)
                            {
                                txtQuant.Text = (Calc.Valor / PrecosBombas.GasPls).ToString("#0.00");
                            }

                            if (comboBox1.SelectedIndex == 2)
                            {
                                txtQuant.Text = (Calc.Valor / PrecosBombas.Gleo).ToString("#0.00");
                            }

                            if (comboBox1.SelectedIndex == 3)
                            {
                                txtQuant.Text = (Calc.Valor / PrecosBombas.GleoPls).ToString("#0.00");
                            }
                        }
                    }

                    // guardar o dinheiro que foi ganho e o combustivel que foi consumido
                    if (!string.IsNullOrEmpty(txtPreco.Text))
                    {
                        DinheiroGasto.Valor = double.Parse(txtPreco.Text);
                        button1.Enabled = false;
                        button2.Enabled = false;
                        txtPreco.Enabled = false;
                        txtQuant.Enabled = false;
                        btnCalc.Text = "Pagar";
                    }
                }
                #endregion   
            }

            if (f == true)
            {
                #region
                    Menu Menu1 = (Menu)this.Owner;

                    if (i == 1)
                    {
                        Info[0].Dinheiro += DinheiroGasto.Valor;
                        #region
                        Menu1.Info2[0].Dinheiro = Info[0].Dinheiro;

                        if (comboBox1.SelectedIndex == 0)
                        {
                            Info[0].Gas += double.Parse(txtQuant.Text);
                            Menu1.Info2[0].Gas = Info[0].Gas;
                            MessageBox.Show("O valor a pagar é: " + Info[0].Dinheiro + "€\n"
                                              + "E pode abastecer: " + Info[0].Gas + "L\n");
                        }

                        if (comboBox1.SelectedIndex == 1)
                        {
                            Info[0].GasPls += double.Parse(txtQuant.Text);
                            Menu1.Info2[0].GasPls = Info[0].GasPls;
                            MessageBox.Show("O valor a pagar é: " + Info[0].Dinheiro + "€\n"
                                              + "E pode abastecer: " + Info[0].GasPls + "L\n");
                        }

                        if (comboBox1.SelectedIndex == 2)
                        {
                            Info[0].Gleo += double.Parse(txtQuant.Text);
                            Menu1.Info2[0].Gleo = Info[0].Gleo;
                            MessageBox.Show("O valor a pagar é: " + Info[0].Dinheiro + "€\n"
                                              + "E pode abastecer: " + Info[0].Gleo + "L\n");
                        }

                        if (comboBox1.SelectedIndex == 3)
                        {
                            Info[0].GleoPls += double.Parse(txtQuant.Text);
                            Menu1.Info2[0].GleoPls = Info[0].GleoPls;
                            MessageBox.Show("O valor a pagar é: " + Info[0].Dinheiro + "€\n"
                                              + "E pode abastecer: " + Info[0].GleoPls + "L\n");
                        }
                        #endregion
                    }
                    if (i == 2)
                    {
                        Info[1].Dinheiro += DinheiroGasto.Valor;
                        #region
                        Menu1.Info2[1].Dinheiro = Info[1].Dinheiro;

                        if (comboBox1.SelectedIndex == 0)
                        {
                            Info[1].Gas += double.Parse(txtQuant.Text);
                            Menu1.Info2[1].Gas = Info[1].Gas;
                            MessageBox.Show("O valor a pagar é: " + Info[1].Dinheiro + "€\n"
                                              + "E pode abastecer: " + Info[1].Gas + "L\n");
                        }

                        if (comboBox1.SelectedIndex == 1)
                        {
                            Info[1].GasPls += double.Parse(txtQuant.Text);
                            Menu1.Info2[1].GasPls = Info[1].GasPls;
                            MessageBox.Show("O valor a pagar é: " + Info[1].Dinheiro + "€\n"
                                              + "E pode abastecer: " + Info[1].GasPls + "L\n");
                        }

                        if (comboBox1.SelectedIndex == 2)
                        {
                            Info[1].Gleo += double.Parse(txtQuant.Text);
                            Menu1.Info2[1].Gleo = Info[1].Gleo;
                            MessageBox.Show("O valor a pagar é: " + Info[1].Dinheiro + "€\n"
                                              + "E pode abastecer: " + Info[1].Gleo + "L\n");
                        }

                        if (comboBox1.SelectedIndex == 3)
                        {
                            Info[1].GleoPls += double.Parse(txtQuant.Text);
                            Menu1.Info2[1].GleoPls = Info[1].GleoPls;
                            MessageBox.Show("O valor a pagar é: " + Info[1].Dinheiro + "€\n"
                                              + "E pode abastecer: " + Info[1].GleoPls + "L\n");
                        }
                        #endregion
                    }
                    if (i == 3)
                    {
                        Info[2].Dinheiro += DinheiroGasto.Valor;
                        #region
                        Menu1.Info2[2].Dinheiro = Info[2].Dinheiro;
                        if (comboBox1.SelectedIndex == 0)
                        {
                            Info[2].Gas += double.Parse(txtQuant.Text);
                            Menu1.Info2[2].Gas = Info[2].Gas;
                            MessageBox.Show("O valor a pagar é: " + Info[2].Dinheiro + "€\n"
                                              + "E pode abastecer: " + Info[2].Gas + "L\n");
                        }
                        if (comboBox1.SelectedIndex == 1)
                        {
                            Info[2].GasPls += double.Parse(txtQuant.Text);
                            Menu1.Info2[2].GasPls = Info[2].GasPls;
                            MessageBox.Show("O valor a pagar é: " + Info[2].Dinheiro + "€\n"
                                              + "E pode abastecer: " + Info[2].GasPls + "L\n");
                        }
                        if (comboBox1.SelectedIndex == 2)
                        {
                            Info[2].Gleo += double.Parse(txtQuant.Text);
                            Menu1.Info2[2].Gleo = Info[2].Gleo;
                            MessageBox.Show("O valor a pagar é: " + Info[2].Dinheiro + "€\n"
                                              + "E pode abastecer: " + Info[2].Gleo + "L\n");
                        }
                        if (comboBox1.SelectedIndex == 3)
                        {
                            Info[2].GleoPls += double.Parse(txtQuant.Text);
                            Menu1.Info2[2].GleoPls = Info[2].GleoPls;
                            MessageBox.Show("O valor a pagar é: " + Info[2].Dinheiro + "€\n"
                                              + "E pode abastecer: " + Info[2].GleoPls + "L\n");
                        }
                        #endregion
                    }
                    if (i == 4)
                    {
                        Info[3].Dinheiro += DinheiroGasto.Valor;
                        #region
                        Menu1.Info2[3].Dinheiro = Info[3].Dinheiro;
                        if (comboBox1.SelectedIndex == 0)
                        {
                            Info[3].Gas += double.Parse(txtQuant.Text);
                            Menu1.Info2[3].Gas = Info[3].Gas;
                            MessageBox.Show("O valor a pagar é: " + Info[3].Dinheiro + "€\n"
                                              + "E pode abastecer: " + Info[3].Gas + "L\n");

                        } if (comboBox1.SelectedIndex == 1)
                        {
                            Info[3].GasPls += double.Parse(txtQuant.Text);
                            Menu1.Info2[3].GasPls = Info[3].GasPls;
                            MessageBox.Show("O valor a pagar é: " + Info[3].Dinheiro + "€\n"
                                              + "E pode abastecer: " + Info[3].GasPls + "L\n");

                        } if (comboBox1.SelectedIndex == 2)
                        {
                            Info[3].Gleo += double.Parse(txtQuant.Text);
                            Menu1.Info2[3].Gleo = Info[3].Gleo;
                            MessageBox.Show("O valor a pagar é: " + Info[3].Dinheiro + "€\n"
                                              + "E pode abastecer: " + Info[3].Gleo + "L\n");

                        } if (comboBox1.SelectedIndex == 3)
                        {
                            Info[3].GleoPls += double.Parse(txtQuant.Text);
                            Menu1.Info2[3].GleoPls = Info[3].GleoPls;
                            MessageBox.Show("O valor a pagar é: " + Info[3].Dinheiro + "€\n"
                                              + "E pode abastecer: " + Info[3].GleoPls + "L\n");
                        }
                        #endregion
                    }
                    this.Close();
                    #endregion
            }
           
          f = true;     
        }
         
        //botao de cancelar ( reinicia tudo no form)
        private void button3_Click(object sender, EventArgs e)
        {
            txtPreco.Enabled = false;
            txtQuant.Enabled = false;
            Editar2 = false;
            txtQuant.Text = "";
            txtPreco.Text = "";
            Editar = false;
            Editar2 = false;
            button1.Enabled = true;
            button2.Enabled = true;
            comboBox1.SelectedIndex = -1;
            btnCalc.Text = "Calcular";
            f = false;
        }
    
        #endregion

        //KeyPress (açao que acontece quando se carrega em qualcer tecla a partir das textboxs, que nao permite que sejam inseridas letras nem caracteres para alem da virgula nas mesmas)
        #region
        private void txtQuant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ','))
            {
                e.Handled = true;
            }

        }

        #endregion
        //Timer ( de 1 em 1 milisegundo atualiza a quantidade de dinheiro que ja foi usado em cada bomba)
    }
}
