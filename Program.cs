using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace GcodeParse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
        foreach
	
    }

}

    /*
    StreamReader sr = new StreamReader("D:/Code/10. MotionController/GcodeFile")
    private void Send_Click(object sender, EventArgs e)
    {
        string username = textBox5.Text;
        Console.WriteLine(username);
        textBox4.Text = textBox4.Text + textBox5.Text + "\r\n";  //+Environment.NewLine 默认换行符
        this.textBox4.Focus();//获取焦点
        this.textBox4.Select(this.textBox4.TextLength, 0);//光标定位到文本最后
        this.textBox4.ScrollToCaret();//滚动到光标处


        string gcode = textBox5.Text;    //Trim（）去除头尾空格,ToUpper()全部大写.StartsWith("G")判断首位是不是G
        string[] gcodeList = gcode.Split(new string[] { "\r\n" }, StringSplitOptions.None); //Split()，分隔字符串。通过“ ”截取数组，截取出单行指令。

        Dictionary<string, double> gcodeParameter = new Dictionary<string, double>(); //创建一个字典。Dictionary提供快速的基于键值的元素查找。可以根据key得到value
        for (int clist = 0; clist < gcodeList.Length; ++clist)
        {

            if (gcodeList[clist].Trim().ToUpper().StartsWith("G")) //*****这里后续应该写成直接提取G01 G101 这样的形式，从第一个字母开始，到下一个字母截止
            {
                Console.WriteLine("G");
                textBox3.Text = "G";

                string[] subGcodes = gcodeList[clist].Split(' ');  //Split()，分隔字符串。通过“ ”截取数组。
                string gcodeNumber = subGcodes[0].Substring(1, subGcodes[0].Length - 1);    //Substring（），截取首段字符串。提取除关键“G”以外的数值。 
                string gcodeCommand = gcodeNumber.TrimStart('0');   //保留指令的有效数值

                for (int i = 1; i < subGcodes.Length; ++i)  //提取单行指令的 单段数据。
                {
                    string GcodeKey = subGcodes[i].Substring(0, 1);  //提取GcodeKey ,即 Dictionary 的字典位置。
                    if (GcodeKey != null)
                    {
                        double GcodeNumber = double.Parse(subGcodes[i].Substring(1, subGcodes[i].Length - 1));    //double.Parse 强制转化 double

                        if (gcodeParameter.ContainsKey(GcodeKey) == false)
                        {
                            //不存在，则添加
                            gcodeParameter.Add(GcodeKey, GcodeNumber);  //添加一组 集合
                            Console.WriteLine("新增_" + GcodeKey + gcodeParameter[GcodeKey]);
                            Console.WriteLine(gcodeParameter[GcodeKey]);
                        }
                        else
                        {
                            gcodeParameter[GcodeKey] = GcodeNumber;  //添加一组 集合
                            Console.WriteLine("修改_" + GcodeKey + gcodeParameter[GcodeKey]);
                            Console.WriteLine(gcodeParameter[GcodeKey]);
                            //如果指定的字典的键存在
                            //gcodeParameter[GcodeKey] = GcodeNumber;
                        }
                    }
                }

                if (gcodeCommand == "1")  //判断有效数值，是否为“G01”指令
                {
                    textBox3.Text = "G01";
                    Console.WriteLine("G");
                    // Console.WriteLine("{0},{1}", "X", gcodeParameter["X"]);
                    // Console.WriteLine("Key:{0},Value:{1}", "X", gcodeParameter["X"]);
                    double masagek = gcodeParameter["X"];
                    Console.WriteLine(masagek);

                    Dist[0] = gcodeParameter["X"];
                    Dist[1] = gcodeParameter["Y"];
                    Dist[2] = gcodeParameter["Z"];
                    // Dist[3] = gcodeParameter["U"];
                    MyMax_Vel = gcodeParameter["F"];
                    vectorInit();   //插补初始化
                    vectorRun();    //插补运行

                }
                else if (gcodeCommand == "2")    //判断有效数值，是否为“G02”指令
                {
                    textBox3.Text = "G02";
                }


            }
            else if (gcodeList[clist].Trim().ToUpper().StartsWith("M"))
            {
                Console.WriteLine("M");
                textBox3.Text = "M";

                string[] subGcodes = gcodeList[clist].Split(' ');  //Split()，分隔字符串。通过“ ”截取数组。
                string gcodeNumber = subGcodes[0].Substring(1, subGcodes[0].Length - 1);    //Substring（），截取首段字符串。提取除关键“G”以外的数值。 
                string gcodeCommand = gcodeNumber.TrimStart('0');   //保留指令的有效数值
                Console.WriteLine(gcodeCommand);
                for (int i = 1; i < subGcodes.Length; ++i)  //提取单行指令的 单段数据。
                {
                    string GcodeKey = subGcodes[i].Substring(0, 1);  //提取GcodeKey ,即 Dictionary 的字典位置。
                    if (GcodeKey != null)
                    {
                        double GcodeNumber = double.Parse(subGcodes[i].Substring(1, subGcodes[i].Length - 1));    //double.Parse 强制转化 double

                        if (gcodeParameter.ContainsKey(GcodeKey) == false)
                        {
                            //不存在，则添加
                            gcodeParameter.Add(GcodeKey, GcodeNumber);  //添加一组 集合
                            Console.WriteLine("新增_" + GcodeKey + gcodeParameter[GcodeKey]);
                            Console.WriteLine(gcodeParameter[GcodeKey]);
                        }
                        else
                        {
                            gcodeParameter[GcodeKey] = GcodeNumber;  //添加一组 集合
                            Console.WriteLine("修改_" + GcodeKey + gcodeParameter[GcodeKey]);
                            Console.WriteLine(gcodeParameter[GcodeKey]);
                            //如果指定的字典的键存在
                            //gcodeParameter[GcodeKey] = GcodeNumber;
                        }
                    }
                }
                if (gcodeCommand == "101")  //判断有效数值，是否为“G01”指令
                {
                    textBox3.Text = "M101";
                    Console.WriteLine("M101");
                    // Console.WriteLine("{0},{1}", "X", gcodeParameter["X"]);
                    // Console.WriteLine("Key:{0},Value:{1}", "X", gcodeParameter["X"]);
                    ushort IO_on = 1;
                    ushort IO_off = 0;
                    LTSMC.smc_conti_delay_outbit_to_start(_ConnectNo, MyCrd, 1, IO_off, 0, 0, 0); 
                    //连续插补中相对于轨迹段起点IO滞后输出（段内执行)、
                    // LTSMC.smc_write_outbit(_ConnectNo, 1, IO_on); //插补中立刻操作IO
                    // LTSMC.smc_conti_write_outbit(_ConnectNo, MyCrd, 0, 1, 5.0);

                    //参数：ConnectNo 指定链接号：0 - 7,默认值0
                    //Crd 坐标系号，取值范围：0~1
                    //bitno 输出口号，取值范围：0~31
                    //on_off 电平状态，0：低电平，1：高电平
                    //delay_value 滞后值，单位：s（滞后时间模式）或unit（滞后距离模式）
                    //delay_mode 滞后模式，0：滞后时间，1：滞后距离
                    //ReverseTime 电平输出后的延时翻转时间，单位：s
                }
                else if (gcodeCommand == "103")    //判断有效数值，是否为“G02”指令
                {
                    textBox3.Text = "M103";
                    Console.WriteLine("M103");
                    ushort IO_on = 1;
                    ushort IO_off = 0;
                    LTSMC.smc_conti_ahead_outbit_to_stop(_ConnectNo, MyCrd, 1, IO_on, 2.0, 0, 0);     //连续插补中相对于轨迹段终点IO提前输出（段内执行
                                                                                                      //参数：ConnectNo 指定链接号：0 - 7,默认值0
                                                                                                      //Crd 坐标系号，取值范围：0~1
                                                                                                      //bitno 输出口号，取值范围：0~31
                                                                                                      //on_off 电平状态，0：低电平，1：高电平
                                                                                                      //ahead_value 提前值，单位：s（提前时间模式）或unit（提前距离模式）
                                                                                                      //ahead_mode 提前模式，0：提前时间，1：提前距离
                                                                                                      //ReverseTime 电平输出后的延时翻转时间，单位：s     ***延时翻转，会对IO做一个短时间的翻转，然后再变化。
                }


            }


        }

        //第八步、关闭连续插补缓冲区
        uint IoMask = 0;
        LTSMC.smc_conti_clear_io_action(_ConnectNo, MyCrd, 0);
        LTSMC.smc_conti_close_list(_ConnectNo, MyCrd);
        textBox3.Text = "";
        textBox5.Text = "";
    }
    */

