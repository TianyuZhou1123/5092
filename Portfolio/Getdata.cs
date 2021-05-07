using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio
{
    class Getdata
    {
        //get the Id from Instrument
        static public int InstrumentID(string Ticker)
        {
            int Instid = 0;
            foreach (Instrument i in (from i in Program.PMC.Instruments where i.Ticker == Ticker select i))
                Instid = i.ID;
            return Instid;
        }
        //K
        static public double strike(int Instid)
        {
            Instrument instrument = Program.PMC.Instruments.SingleOrDefault(i => i.ID == Instid);
            double strike = 0;
            if (instrument.InstType.Typename != "Stock")
                strike = Convert.ToDouble(instrument.Strike);
            return strike;
        }
        //S
        static public double S(int id)
        {
            Trade trade = Program.PMC.Trades.SingleOrDefault(i => i.TradeID == id);
            StockPrice s;
            //stock
            if (trade.Instrument.InstType.Typename == "Stock")
                s = trade.Instrument.StockPrices.OrderByDescending(i => i.Date).First();
            //option price == underlying price
            else
                s = Program.PMC.Instruments.SingleOrDefault(i => i.Ticker == trade.Instrument.Underlying).StockPrices.OrderByDescending(j => j.Date).First();
            return Convert.ToDouble(s.ClosingPrice);
        }
        //T
        static public double tenor(int Instid)
        {
            double tenor = 0;
            foreach (Instrument i in (from i in Program.PMC.Instruments where i.ID == Instid select i))
                tenor = Convert.ToDouble(i.Tenor);
            return tenor;
        }
        //get the instrument
        static public Instrument instrument(int Instid)
        {
            Instrument instrument = new Instrument();
            foreach (Instrument i in (from i in Program.PMC.Instruments where i.ID == Instid select i))
                instrument = i;
            return instrument;
        }
        //R
        static public double rate(double tenor, int id)
        {
            double rate = 0;
            if ((from i in Program.PMC.Instruments where (i.InstType.Typename == "Stock") && (i.ID == id) select i).Count() == 0)
            {
                if ((from i in Program.PMC.InterestRates select i).Count() > 2)
                {
                    if (((from i in Program.PMC.InterestRates where i.Tenor == tenor select i.Tenor).DefaultIfEmpty(-1).First()) == -1)
                    {
                        if (((from i in Program.PMC.InterestRates orderby i.Tenor ascending where i.Tenor > tenor select i.Rate).DefaultIfEmpty(-1).First()) == -1)
                        {
                            var firstone = (from i in Program.PMC.InterestRates orderby i.Tenor descending select i).First();
                            var secondone = (from i in Program.PMC.InterestRates orderby i.Tenor descending select i).Skip(1).First();
                            rate = Convert.ToDouble(firstone.Rate + (tenor - firstone.Tenor) * (firstone.Rate - secondone.Rate) / (firstone.Tenor - secondone.Tenor));
                        }
                        else
                        {
                            var firstone = (from i in Program.PMC.InterestRates orderby i.Tenor ascending where i.Tenor > tenor select i).FirstOrDefault();
                            var secondone = (from i in Program.PMC.InterestRates orderby i.Tenor descending where i.Tenor <= tenor select i).First();
                            rate = Convert.ToDouble(secondone.Rate + (tenor - secondone.Tenor) * (firstone.Rate - secondone.Rate) / (firstone.Tenor - secondone.Tenor));
                        }
                    }
                    else
                        rate = Convert.ToDouble((from i in Program.PMC.InterestRates where i.Tenor == tenor select i.Rate).First());
                }
            }
            return rate;
        }
    }
}
