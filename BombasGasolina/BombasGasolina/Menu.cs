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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.Text = "Gerir Bombas!!!!!!!!!!!!!!!!!!!!!!!!";
        }

        //Decaraçao de variaveis
        #region
        public Boolean[] EstadoBombas = new Boolean[4];
        public Boolean PrecoCombustivel;
        public Boolean Editar = false;
        public Precos Pagamento;
        public BombasTotal[] Info2 = new BombasTotal[4];
        #endregion

        //Guarda os valores da textboxs em variaveis quando o form é aberto
        #region
        public void Menu_Load(object sender, EventArgs e)
        {
            Pagamento.Gas = double.Parse(textBox1.Text);
            Pagamento.GasPls = double.Parse(textBox2.Text);
            Pagamento.Gleo = double.Parse(textBox3.Text);
            Pagamento.GleoPls = double.Parse(textBox4.Text); 

        }
        #endregion

        //Botoes
        #region

        //botao que abre o form Bomba1, para gerir a bomba 1 e passa os valores dos combustiveis para o form Bombas
        private void button1_Click(object sender, EventArgs e)
        {
            if (EstadoBombas[0] == false && btnBomba1.BackColor == Color.Lime)
            {
                EstadoBombas[0] = true;

                Bombas Bomba1 = new Bombas();

                Bomba1.i = 1;
                Bomba1.Show(this);
                Bomba1.Text = "Bomba 1";
                btnBomba1.BackColor = Color.Red;
                Bomba1.PrecosBombas = this.Pagamento;
                Bomba1.Info[0].Dinheiro = Info2[0].Dinheiro;
                Bomba1.Info[0].Gas = Info2[0].Gas;
                Bomba1.Info[0].GasPls = Info2[0].GasPls;
                Bomba1.Info[0].Gleo = Info2[0].Gleo;
                Bomba1.Info[0].GleoPls = Info2[0].GleoPls;
            
            }

        }

        //botao que abre o form Bomba2, para gerir a bomba 2 e passa os valores dos combustiveis para o form Bombas
        private void button2_Click(object sender, EventArgs e)
        {
            if (EstadoBombas[1] == false && btnBomba2.BackColor == Color.Lime)
            {
                EstadoBombas[1] = true;

                Bombas Bomba2 = new Bombas();

                Bomba2.i = 2;
                Bomba2.Show(this);
                Bomba2.Text = "Bomba 2";
                btnBomba2.BackColor = Color.Red;
                Bomba2.PrecosBombas = this.Pagamento;
                Bomba2.Info[1].Dinheiro = Info2[1].Dinheiro;
                Bomba2.Info[1].Gas = Info2[1].Gas;
                Bomba2.Info[1].GasPls = Info2[1].GasPls;
                Bomba2.Info[1].Gleo = Info2[1].Gleo;
                Bomba2.Info[1].GleoPls = Info2[1].GleoPls;
                
            }
        }

        //botao que abre o form Bomba3, para gerir a bomba 3 e passa os valores dos combustiveis para o form Bombas
        private void button3_Click(object sender, EventArgs e)
        {
            if (EstadoBombas[2] == false && btnBomba3.BackColor == Color.Lime)
            {
                EstadoBombas[2] = true;

                Bombas Bomba3 = new Bombas();

                Bomba3.i = 3;
                Bomba3.Show(this);
                Bomba3.Text = "Bomba 3";
                btnBomba3.BackColor = Color.Red;
                Bomba3.PrecosBombas= this.Pagamento;
                Bomba3.Info[2].Dinheiro = Info2[2].Dinheiro;
                Bomba3.Info[2].Gas = Info2[2].Gas;
                Bomba3.Info[2].GasPls = Info2[2].GasPls;
                Bomba3.Info[2].Gleo = Info2[2].Gleo;
                Bomba3.Info[2].GleoPls = Info2[2].GleoPls;
            }

        }

        //botao que abre o form Bomba4, para gerir a bomba 4 e passa os valores dos combustiveis para o form Bombas
        private void button4_Click(object sender, EventArgs e)
        {
            if (EstadoBombas[3] == false && btnBomba4.BackColor == Color.Lime)
            {
                EstadoBombas[3] = true;

                Bombas Bomba4 = new Bombas();

                Bomba4.i = 4;
                Bomba4.Show(this);
                Bomba4.Text = "Bomba 4";
                btnBomba4.BackColor = Color.Red;
                Bomba4.PrecosBombas = this.Pagamento;
                Bomba4.Info[3].Dinheiro = Info2[3].Dinheiro;
                Bomba4.Info[3].Gas = Info2[3].Gas;
                Bomba4.Info[3].GasPls = Info2[3].GasPls;
                Bomba4.Info[3].Gleo = Info2[3].Gleo;
                Bomba4.Info[3].GleoPls = Info2[3].GleoPls;
            }
        }

        // botao para alterar os preços dos combustiveis guarda os valores novos em variaveis, depois do valor das mesmas ser alterado
        private void btnEditVal_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                Editar = true;
                btnEditVal.Text = "Confirmar";
                btnCancelar.Visible = true;
                btnCancelar.Enabled = true;
               
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                Editar = false;
                btnEditVal.Text = "Editar Valores";
                btnCancelar.Visible = false;
                btnCancelar.Enabled = false;
                if (!string.IsNullOrEmpty(textBox1.Text))
                    Pagamento.Gas = double.Parse(textBox1.Text);
                if (!string.IsNullOrEmpty(textBox2.Text))
                    Pagamento.GasPls = double.Parse(textBox2.Text);
                if (!string.IsNullOrEmpty(textBox3.Text))
                    Pagamento.Gleo = double.Parse(textBox3.Text);
                if (!string.IsNullOrEmpty(textBox4.Text))
                    Pagamento.GleoPls = double.Parse(textBox4.Text);
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            Editar = false;
            btnEditVal.Text = "Editar Valores";
            btnCancelar.Visible = false;
            btnCancelar.Enabled = false;
            textBox1.Text = Pagamento.Gas.ToString();
            textBox2.Text = Pagamento.GasPls.ToString();
            textBox3.Text = Pagamento.Gleo.ToString();
            textBox4.Text = Pagamento.GleoPls.ToString();

        }

        private void btnLucroB1_Click(object sender, EventArgs e)
        {
            string message = ("O Dinheiro acumulado na bomba 1 foi: " + Info2[0].Dinheiro + "€\n" +
                              "A Gasolina comsumida na bomba 1 foi: " + Info2[0].Gas + "L\n" +
                              "A Gasolina+ consumida na bomba 1 foi: " + Info2[0].GasPls + "L\n" +
                              "O Gasoleo comsumido na bomba 1 foi: " + Info2[0].Gleo + "L\n" +
                              "O Gasoleo+ consumido na bomba 1 foi: " + Info2[0].GleoPls + "L\n");

            MessageBox.Show(message);
        }

        private void btnLucroB2_Click(object sender, EventArgs e)
        {
            string message = ("O Dinheiro acumulado na bomba 2 foi: " + Info2[1].Dinheiro + "€\n" +
                              "A Gasolina comsumida bomba 2 foi: " + Info2[1].Gas + "L\n" +
                              "A Gasolina+ consumida bomba 2 foi: " + Info2[1].GasPls + "L\n" +
                              "O Gasoleo comsumido bomba 2 foi: " + Info2[1].Gleo + "L\n" +
                              "O Gasoleo+ consumido bomba 2 foi: " + Info2[1].GleoPls + "L\n");
            MessageBox.Show(message);
        }

        private void btnLucroB3_Click(object sender, EventArgs e)
        {
            string message = ("O Dinheiro acumulado na bomba 3 foi: " + Info2[2].Dinheiro + "€\n" +
                              "A Gasolina comsumida bomba 3 foi: " + Info2[2].Gas + "L\n" +
                              "A Gasolina+ consumida bomba 3 foi: " + Info2[2].GasPls + "L\n" +
                              "O Gasoleo comsumido bomba 3 foi: " + Info2[2].Gleo + "L\n" +
                              "O Gasoleo+ consumido bomba 3 foi: " + Info2[2].GleoPls + "L\n");
            MessageBox.Show(message);
        }

        private void btnLucroB4_Click(object sender, EventArgs e)
        {
            string message = ("O Dinheiro acumulado na bomba 4 foi: " + Info2[3].Dinheiro + "€\n" +
                              "A Gasolina comsumida na bomba 4 foi: " + Info2[3].Gas + "L\n" +
                              "A Gasolina+ consumida na bomba 4 foi: " + Info2[3].GasPls + "L\n" +
                              "O Gasoleo comsumido na bomba 4 foi: " + Info2[3].Gleo + "L\n" +
                              "O Gasoleo+ consumido na bomba 4 foi: " + Info2[3].GleoPls + "L\n");
            MessageBox.Show(message);
        }


        private void btnInfoTotal_Click(object sender, EventArgs e)
        {
            string message = ("O Dinheiro acumulado por todas as bombas foi: " + (Info2[3].Dinheiro + Info2[2].Dinheiro + Info2[1].Dinheiro + Info2[0].Dinheiro) + "€\n" +
                              "A Gasolina comsumida por todas as bombas foi: " + (Info2[3].Gas + Info2[2].Gas + Info2[1].Gas + Info2[0].Gas) + "L\n" +
                              "A Gasolina+ consumida por todas as bombas foi: " + (Info2[3].GasPls + Info2[2].GasPls + Info2[1].GasPls + Info2[0].GasPls) + "L\n" +
                              "O Gasoleo comsumido por todas as bombas foi: " + (Info2[3].Gleo + Info2[2].Gleo + Info2[1].Gleo + Info2[0].Gleo) + "L\n" +
                              "O Gasoleo+ consumido por todas as bombas foi: " + (Info2[3].GleoPls + Info2[2].GleoPls + Info2[1].GleoPls + Info2[0].GleoPls) + "L\n");
            MessageBox.Show(message);
        }
        #endregion
        
        //Timers (simula o carro a abastecer alterando a cor do botao apos 3 segundos)
        #region
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnBomba1.BackColor = Color.Lime;
            timer1.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            btnBomba2.BackColor = Color.Lime;
            timer2.Enabled = false;

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            btnBomba3.BackColor = Color.Lime;
            timer3.Enabled = false;

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            btnBomba4.BackColor = Color.Lime;
            timer4.Enabled = false;

        }

        private void timer5_Tick(object sender, EventArgs e)
        {

        }
        
        #endregion

        //KeyPress (açao que acontece quando se carrega em qualcer tecla a partir das textboxs, que nao permite que sejam inseridas letras nem caracteres para alem da virgula nas mesmas)
        #region
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        #endregion


    }
}
