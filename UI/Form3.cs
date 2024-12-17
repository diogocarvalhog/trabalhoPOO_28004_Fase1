using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConcertManager;

namespace UI
{
    public partial class Form3 : Form
    {
        private ListBands listBands = new ListBands();

        public Form3()
        {
            InitializeComponent();
            this.Load += Form3_Load;

            // Associar evento SelectedIndexChanged ao comboBox1
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        // Evento Form_Load para inicializar os dados
        private void Form3_Load(object sender, EventArgs e)
        {
            // Criar bandas e adicionar concertos associados com preço
            Bands coldplay = new Bands("Coldplay", "Pop Rock", "Chris, Jonny, Guy, Will");
            coldplay.AddConcert(new Concerts("Palco Principal", 500, "Coldplay Live", "15/11/2024", 75.50));
            coldplay.AddConcert(new Concerts("Palco Principal", 500, "Coldplay Night", "20/12/2024", 85.00));

            Bands metallica = new Bands("Metallica", "Heavy Metal", "James, Lars, Kirk, Robert");
            metallica.AddConcert(new Concerts("Palco Secundário", 300, "Metallica Tour", "10/10/2024", 90.00));

            Bands imagineDragons = new Bands("Imagine Dragons", "Alternative Rock", "Dan, Wayne, Ben, Daniel");
            imagineDragons.AddConcert(new Concerts("Palco Arena", 600, "ID Live", "25/09/2024", 65.00));

            // Adicionar bandas ao gerenciador
            listBands.AddBand(coldplay);
            listBands.AddBand(metallica);
            listBands.AddBand(imagineDragons);

            // Preencher comboBox1 com os nomes das bandas
            foreach (Bands band in listBands.BandsList)
            {
                comboBox1.Items.Add(band.bandName);
            }
        }

        // Evento chamado quando o usuário seleciona uma banda no comboBox1
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Limpar os itens do comboBox2
            comboBox2.Items.Clear();

            // Verificar se uma banda foi selecionada
            if (comboBox1.SelectedItem != null)
            {
                string selectedBandName = comboBox1.SelectedItem.ToString();

                // Encontrar a banda correspondente
                Bands selectedBand = listBands.BandsList.Find(b => b.bandName == selectedBandName);

                if (selectedBand != null)
                {
                    // Adicionar os concertos da banda (data e preço) no comboBox2
                    foreach (var concert in selectedBand.concerts)
                    {
                        string concertInfo = $"{concert.date} - {concert.price:C2}"; // Data e preço formatado
                        comboBox2.Items.Add(concertInfo);
                    }
                }
            }
        }

        private void Form3_Load_1(object sender, EventArgs e)
        {

        }
    }
}