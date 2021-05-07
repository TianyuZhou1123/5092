using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Portfolio
{
    public partial class Generatedata : Form
    {
        public Generatedata()
        {
            InitializeComponent();
        }

        private void button_generate_Click(object sender, EventArgs e)
        {
            //add data into instrument type table
            //Program.PMC.InstTypes.Add(new InstType()
            //{
            //    Typename = "Stock"
            //});
            //Program.PMC.InstTypes.Add(new InstType()
            //{
            //    Typename = "EuropeanOption"
            //});
            //Program.PMC.InstTypes.Add(new InstType()
            //{
            //    Typename = "AsianOption"
            //});
            //Program.PMC.InstTypes.Add(new InstType()
            //{
            //    Typename = "DigitalOption"
            //});
            //Program.PMC.InstTypes.Add(new InstType()
            //{
            //    Typename = "BarrierOption"
            //});
            //Program.PMC.InstTypes.Add(new InstType()
            //{
            //    Typename = "LookbackOption"
            //});
            //Program.PMC.InstTypes.Add(new InstType()
            //{
            //    Typename = "RangeOption"
            //});
            //add data into Instrument table
            Program.PMC.Instruments.Add(new Instrument()
            {
                CompanyName = "Miscroft Corp.",
                Ticker = "MSFTC90",
                Exchange = "NASDAQ",
                Underlying = "MSFT",
                Strike = 90,
                Tenor = 0.5,
                IsCall = true,
                TypeID = 2
            });
            Program.PMC.Instruments.Add(new Instrument()
            {
                CompanyName = "AAA",
                Ticker = "AA",
                Exchange = "A",
                Underlying = "",
                TypeID = 1
            });
            Program.PMC.Instruments.Add(new Instrument()
            {
                CompanyName = "AAA",
                Ticker = "BB",
                Exchange = "B",
                Underlying = "AA",
                Strike = 90,
                Tenor = 1,
                IsCall = true,
                Rebate = 0,
                Barrier = 0,
                TypeID = 2
            });
            Program.PMC.Instruments.Add(new Instrument()
            {
                CompanyName = "AAA",
                Ticker = "CC",
                Exchange = "C",
                Underlying = "AA",
                Strike = 60,
                Tenor = 1,
                IsCall = true,
                Rebate = 0,
                Barrier = 0,
                TypeID = 3
            });
            Program.PMC.Instruments.Add(new Instrument()
            {
                CompanyName = "AAA",
                Ticker = "DD",
                Exchange = "D",
                Underlying = "AA",
                Strike = 90,
                Tenor = 0.6,
                IsCall = true,
                Rebate = 1,
                Barrier = 0,
                TypeID = 4
            });
            Program.PMC.Instruments.Add(new Instrument()
            {
                CompanyName = "GGG",
                Ticker = "GG",
                Exchange = "G",
                Underlying = "",
                TypeID = 1
            });
            Program.PMC.Instruments.Add(new Instrument()
            {
                CompanyName = "Miscroft Corp.",
                Ticker = "EE",
                Exchange = "E",
                Underlying = "MSFT",
                Strike = 80,
                Tenor = 1,
                IsCall = false,
                TypeID = 2
            });
            //add data into InterestRates table
            Program.PMC.InterestRates.Add(new InterestRate()
            {
                Tenor = 1,
                Rate = 3
            });
            Program.PMC.InterestRates.Add(new InterestRate()
            {
                Tenor = 2,
                Rate = 4
            });
            Program.PMC.InterestRates.Add(new InterestRate()
            {
                Tenor = 0.5,
                Rate = 2
            });
            //add data into prices table
            Program.PMC.StockPrices.Add(new StockPrice()
            {
                Date = System.DateTime.Today,
                ClosingPrice = 10,
                InstrumentID = 2
            });
            Program.PMC.StockPrices.Add(new StockPrice()
            {
                Date = System.DateTime.Today,
                ClosingPrice = 20,
                InstrumentID = 1
            });
            Program.PMC.StockPrices.Add(new StockPrice()
            {
                Date = System.DateTime.Today,
                ClosingPrice = 40,
                InstrumentID = 3
            });
            Program.PMC.StockPrices.Add(new StockPrice()
            {
                Date = System.DateTime.Today,
                ClosingPrice = 30,
                InstrumentID = 2
            });
            Program.PMC.StockPrices.Add(new StockPrice()
            {
                Date = System.DateTime.Today,
                ClosingPrice = 60,
                InstrumentID = 6
            });
            //add data into Trades table
            Program.PMC.Trades.Add(new Trade()
            {
                IsBuy = true,
                Quantity = 1,
                Price = 30,
                Timestamp = System.DateTime.Now,
                InstrumentID = 2
            });
            Program.PMC.Trades.Add(new Trade()
            {
                IsBuy = false,
                Quantity = 2,
                Price = 40,
                Timestamp = System.DateTime.Now,
                InstrumentID = 2
            });
            Program.PMC.Trades.Add(new Trade()
            {
                IsBuy = true,
                Quantity = 1,
                Price = 30,
                Timestamp = System.DateTime.Now,
                InstrumentID = 4
            });
            Program.PMC.SaveChanges();
            MessageBox.Show("Add data to SQL successfully!");
        }

        private void Generatedata_Load(object sender, EventArgs e)
        {

        }
    }
}
