using System;
using System.Windows.Forms;
using System.Xml;

namespace xTrade
{
    public partial class ManageData : Form
    {
        public ManageData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlTextReader reader = new XmlTextReader("Tovars.xml");

            //ArrayList orders = new ArrayList();

            string txt = string.Empty;

            int xCodeTv;
            string xName;
            int xNimP;
            float xCost1;
            float xCost2;
            int xRemains;
            bool xStatus;

            while (reader.Read())
                if (reader.NodeType == XmlNodeType.Element)
                    if (reader.Name == "xTovars")
                    {
             
                        //Produce order = new Produce();

                        int indx = 0; 

                        while (reader.Read() && (reader.Name == "Group" || reader.NodeType == XmlNodeType.Whitespace))
                        {
                            if (reader.NodeType != XmlNodeType.Whitespace)
                            {
                                TypePr TP = new TypePr()
                                                {
                                                    Name = reader.GetAttribute("Code")
                                                };

                                TP.Insert();

                                indx = TypePr.GetLastItem();

                                while (reader.Read() && (reader.Name == "Item" || reader.NodeType == XmlNodeType.Whitespace))
                                {
                                    //int xTvID = myReader.GetInt32(0);

                                    if (reader.NodeType != XmlNodeType.Whitespace)
                                    {

                                        //MessageBox.Show(reader.GetAttribute("Code"));

                                        xCodeTv = int.Parse(reader.GetAttribute("Code"));
                                        int xTypeID = indx;
                                        xName = reader.GetAttribute("Desc");
                                        xNimP = int.Parse(reader.GetAttribute("CntinP"));
                                        xCost1 = float.Parse(reader.GetAttribute("Price1"));
                                        xCost2 = float.Parse(reader.GetAttribute("Price2"));
                                        xRemains = int.Parse(reader.GetAttribute("Rem"));
                                        xStatus = xRemains > 0 ? true : false;

                                        ProduceClass Mc = new ProduceClass()
                                                              {
                                                                  Name = xName,
                                                                  CodeTv = xCodeTv,
                                                                  //Cost1 = xCost1,
                                                                  //Cost2 = xCost2,
                                                                  NimP = xNimP,
                                                                  TypeID = xTypeID,
                                                                  Status = xStatus,
                                                                  Remains = xRemains
                                                                  //,
                                                                  //TvID = 1
                                                              };

                                        Mc.Insert();

                                        int TvLID = ProduceClass.GetLastItem();

                                        Cost Ct = new Cost()
                                                      {
                                                          TvID = TvLID,
                                                          CurrencyID = 1,
                                                          CostTv = xCost1
                                                      };

                                        Ct.Insert();

                                        Cost Cta = new Cost()
                                        {
                                            TvID = TvLID,
                                            CurrencyID = 2,
                                            CostTv = xCost2
                                        };

                                        Cta.Insert();

                                        //if (!(reader.NodeType == XmlNodeType.Whitespace))
                                        // order.AddTovar(int.Parse(reader.GetAttribute("Code")), reader.GetAttribute("Desc"));

                                    }
                                }
                            }
                        }

                        // orders.Add(order);
                    }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Cost.ClearTable();
            ProduceClass.ClearTable();
            TypePr.ClearTable();
        }
    }
}
