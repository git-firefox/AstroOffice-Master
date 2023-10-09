using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SixLabors.ImageSharp.Drawing.Processing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using WinDrawing = System.Drawing;


namespace Kunda
{
    public class Kundali
    {
        [DebuggerNonUserCode]
        public Kundali()
        {
        }

        private float CHORD(ref double a, ref int X2, ref double b, ref double H, ref double d2r, ref float phinc, ref float zra, ref double X1, ref double r2d, ref double xx, ref double inc)
        {
            float h;
            H = a * (double)X2 - b;
            double num = Math.Cos(H * d2r) + (double)phinc * Math.Sin((double)zra + (double)X2 * d2r);
            while (true)
            {
                H = a * X1 - b;
                double num1 = Math.Cos(H * d2r) + (double)phinc * Math.Sin((double)zra + X1 * d2r);
                if (Math.Abs(num1) >= 0.001)
                {
                    double x2 = ((double)X2 - X1) * num1 / (num - num1);
                    X1 -= x2;
                    //if (!true)
                    //{
                    //    h = (float)H;
                    //    break;
                    //}
                }
                else
                {
                    xx = X1;
                    h = this.Ra2Longi(ref zra, ref r2d, ref xx, ref d2r, ref inc);
                    break;
                }
            }
            return h;
        }

        private double F_560(ref double r2d, ref double SP, ref double b, ref double pln, ref double d2r, ref float ert, ref double Se)
        {
            double sP = SP * Math.Cos(b) * Math.Cos(d2r * pln) - Se * Math.Cos(d2r * (double)ert);
            double num = SP * Math.Cos(b) * Math.Sin(d2r * pln) - Se * Math.Sin(d2r * (double)ert);
            if (Math.Abs(sP) >= 1E-05)
            {
                pln = r2d * Math.Atan(num / sP);
                if (sP < 0)
                {
                    pln += 180;
                }
            }
            else
            {
                pln = (double)(checked(90 * Math.Sign(num / sP)));
            }
            return pln;
        }

        private float FnRed(ref float x)
        {
            float single = (float)(360 * ((double)(x / 360f) - Math.Floor((double)(x / 360f))));
            return single;
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public string Gen_Kundali(string lin, float lagan)
        {
            float single;
            int num;
            string str;
            double num1 = 0;
            int num2;
            float single1;
            int num3 = 0;
            double num4;
            string str1 = "";
            string str2 = "";
            StringBuilder stringBuilder = new StringBuilder();
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            string str7 = "";
            MDLKundali.QPlanet[1].pName = "सूर्य";
            MDLKundali.QPlanet[1].pNameENG = "Sun";
            MDLKundali.QPlanet[2].pName = "चंद्र";
            MDLKundali.QPlanet[2].pNameENG = "Moo";
            MDLKundali.QPlanet[3].pName = "मंगल";
            MDLKundali.QPlanet[3].pNameENG = "Mar";
            MDLKundali.QPlanet[4].pName = "बुध";
            MDLKundali.QPlanet[4].pNameENG = "Mer";
            MDLKundali.QPlanet[5].pName = "गुरू";
            MDLKundali.QPlanet[5].pNameENG = "Jup";
            MDLKundali.QPlanet[6].pName = "शुक्र";
            MDLKundali.QPlanet[6].pNameENG = "Ven";
            MDLKundali.QPlanet[7].pName = "शनि";
            MDLKundali.QPlanet[7].pNameENG = "Sat";
            MDLKundali.QPlanet[8].pName = "राहु";
            MDLKundali.QPlanet[8].pNameENG = "Rah";
            MDLKundali.QPlanet[9].pName = "केतु";
            MDLKundali.QPlanet[9].pNameENG = "Ket";
            MDLKundali.QPlanet[10].pName = "हर्षल";
            MDLKundali.QPlanet[10].pNameENG = "Her";
            MDLKundali.QPlanet[11].pName = "नेपच्यून";
            MDLKundali.QPlanet[11].pNameENG = "Nep";
            MDLKundali.QPlanet[12].pName = "प्लुटो";
            MDLKundali.QPlanet[12].pNameENG = "Plu";
            string str8 = "Error:";
            MDLKundali.delT = 2.21816614698203E-08;
            MDLKundali.pi = 3.141593;
            MDLKundali.r2d = 180 / MDLKundali.pi;
            MDLKundali.d2r = MDLKundali.pi / 180;
            FileSystem.FileOpen(2, "Planets.Dat", OpenMode.Input, OpenAccess.Read, OpenShare.Shared, -1);
            int num5 = 1;
            do
            {
                FileSystem.Input(2, ref MDLKundali.days[num5]);
                num5 = checked(num5 + 1);
            }
            while (num5 <= 12);
            int num6 = 1;
            do
            {
                FileSystem.Input(2, ref MDLKundali.ras[num6]);
                FileSystem.Input(2, ref MDLKundali.Swami[num6]);
                num6 = checked(num6 + 1);
            }
            while (num6 <= 12);
            int num7 = 1;
            do
            {
                FileSystem.Input(2, ref MDLKundali.bhava[num7]);
                num7 = checked(num7 + 1);
            }
            while (num7 <= 12);
            int num8 = 1;
            do
            {
                FileSystem.Input(2, ref MDLKundali.Nak[num8]);
                num8 = checked(num8 + 1);
            }
            while (num8 <= 27);
            int num9 = 0;
            do
            {
                FileSystem.Input(2, ref MDLKundali.grah[num9]);
                num9 = checked(num9 + 1);
            }
            while (num9 <= 12);
            int[] numArray = new int[] { 2 };
            FileSystem.FileClose(numArray);
            string str9 = lin.Substring(25, Math.Min(6, checked(lin.Length - 25)));
            int num10 = checked((int)Math.Round(Conversion.Val(str9.Substring(0, Math.Min(2, str9.Length)))));
            int num11 = checked((int)Math.Round(Conversion.Val(str9.Substring(3, Math.Min(2, checked(str9.Length - 3))))));
            if (!(num10 > 65 | num11 > 59))
            {
                int integer = Conversions.ToInteger(Interaction.IIf(Operators.CompareString(str9.Substring(Math.Max(checked(str9.Length - 1), 0)), "N", false) == 0, 1, -1));
                float single2 = (float)(MDLKundali.d2r * (double)integer * ((double)num10 + (double)num11 / 60));
                str7 = lin.Substring(17, Math.Min(7, checked(lin.Length - 17)));
                int num12 = checked((int)Math.Round(Conversion.Val(str7.Substring(0, Math.Min(3, str7.Length)))));
                int num13 = checked((int)Math.Round(Conversion.Val(str7.Substring(4, Math.Min(2, checked(str7.Length - 4))))));
                if (!(num12 > 179 | num13 > 59))
                {
                    integer = Conversions.ToInteger(Interaction.IIf(Operators.CompareString(str7.Substring(Math.Max(checked(str7.Length - 1), 0)), "E", false) == 0, 1, -1));
                    float single3 = (float)((double)integer * ((double)num12 + (double)num13 / 60));
                    str6 = lin.Substring(32, Math.Min(6, checked(lin.Length - 32)));
                    integer = Conversions.ToInteger(Interaction.IIf(str6.StartsWith("-"), -1, 1));
                    int num14 = checked((int)Math.Round(Conversion.Val(str6.Substring(1, Math.Min(2, checked(str6.Length - 1))))));
                    int num15 = checked((int)Math.Round(Conversion.Val(str6.Substring(Math.Max(checked(str6.Length - 2), 0)))));
                    float single4 = (float)((double)integer * ((double)num14 + (double)num15 / 60));
                    if (!((double)single4 < -11.9833333333333 | single4 > 12f))
                    {
                        single3 = single4 - single3 / 15f;
                        str5 = lin.Substring(0, Math.Min(10, lin.Length));
                        int num16 = checked((int)Math.Round(Conversion.Val(str5.Substring(0, Math.Min(2, str5.Length)))));
                        int num17 = checked((int)Math.Round(Conversion.Val(str5.Substring(3, Math.Min(2, checked(str5.Length - 3))))));
                        int num18 = checked((int)Math.Round(Conversion.Val(str5.Substring(Math.Max(checked(str5.Length - 4), 0)))));
                        if (num18 < 1900 | num18 > 2200)
                        {
                            str8 = string.Concat(str8, "Invalid Year (1900-2200)");
                        }
                        else if (!(num17 < 1 | num17 > 12))
                        {
                            MDLKundali.days[2] = 28;
                            if (num18 % 4 == 0 & num18 % 100 > 0 | num18 % 400 == 0)
                            {
                                MDLKundali.days[2] = 29;
                            }
                            if (num16 <= MDLKundali.days[num17])
                            {
                                if (num17 < 3)
                                {
                                    num17 = checked(num17 + 12);
                                    num18 = checked(num18 - 1);
                                }
                                int num19 = checked((int)Math.Round((double)(checked(checked(checked(checked(365 * num18) + num18 / 4) - num18 / 100) + num18 / 400)) + Math.Floor(30.6 * (double)(checked(num17 + 1))) + (double)num16 - 686081));
                                double num20 = Math.Floor((double)num18 / 100);
                                double num21 = 2 - num20 + Math.Floor(num20 / 4);
                                double num22 = Math.Floor(365.25 * (double)(checked(num18 + 4716))) + Math.Floor(30.6001 * (double)(checked(num17 + 1))) + (double)num16 + num21 - 1524.5;
                                MDLKundali.t = (num22 - 2451545) / 36525 + MDLKundali.delT;
                                str4 = lin.Substring(11, Math.Min(5, checked(lin.Length - 11)));
                                num14 = checked((int)Math.Round(Conversion.Val(str4.Substring(0, Math.Min(2, str4.Length)))));
                                num15 = checked((int)Math.Round(Conversion.Val(str4.Substring(Math.Max(checked(str4.Length - 2), 0)))));
                                if (num14 <= 23)
                                {
                                    if (num15 > 59)
                                    {
                                        str8 = string.Concat(str8, "Invalid Minute");
                                        str = str8;
                                        return str;
                                    }
                                    float single5 = (float)((double)num14 + (double)num15 / 60);
                                    float single6 = single5 - single3;
                                    MDLKundali.t += (double)((single5 - single4) / 24f / 36525f);
                                    float single7 = (float)((double)num19 / 6940);
                                    float single8 = (float)((double)(single5 - single4) + 5.5);
                                    double num23 = (double)num19 + ((double)single8 - 6.4522) / 24;
                                    if (Operators.CompareString(lin.Substring(Math.Max(checked(lin.Length - 1), 0)), "L", false) != 0)
                                    {
                                        MDLKundali.ayan = MDLKundali.t * 1.395278 + 23.75;
                                    }
                                    else
                                    {
                                        MDLKundali.ayan = MDLKundali.t * 1.396042 + 23.8565;
                                    }
                                    float single9 = (float)(259.087 + 0.98560912 * num23 + 22.1425 + 0.265 * (double)single7);
                                    float single10 = this.FnRed(ref single9);
                                    float single11 = (float)(MDLKundali.d2r * (1407.4 - 0.793333333333333 * (double)num19 / 36525) / 60);
                                    single9 = single10 + 15f * single6 - 90f;
                                    single5 = this.FnRed(ref single9) / 15f;
                                    float single12 = (float)(MDLKundali.d2r * 15 * (double)single5);
                                    single9 = 15f * single5 + 90f;
                                    float single13 = (float)(MDLKundali.d2r * (double)this.FnRed(ref single9));
                                    num20 = Math.Sin((double)single13);
                                    if (num20 != 0)
                                    {
                                        num21 = Math.Cos((double)single11) * Math.Cos((double)single13) - Math.Tan((double)single2) * Math.Sin((double)single11);
                                        if (num21 != 0)
                                        {
                                            single1 = (float)(MDLKundali.r2d * Math.Atan(num20 / num21));
                                            if (num20 > 0 & single1 < 0f)
                                            {
                                                single1 += 180f;
                                            }
                                            if (num20 < 0)
                                            {
                                                if (single1 <= 0f)
                                                {
                                                    single1 += 360f;
                                                }
                                                else
                                                {
                                                    single1 += 180f;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            single1 = (float)(checked(180 - checked(Math.Sign(num20) * 90)));
                                        }
                                    }
                                    else
                                    {
                                        single1 = (float)(MDLKundali.r2d * (double)single13);
                                    }
                                    if (lagan < 500f)
                                    {
                                        single1 = lagan;
                                    }
                                    MDLKundali.bho[0] = single1;
                                    FileSystem.FileOpen(2, "Planets.Dat", OpenMode.Input, OpenAccess.Read, OpenShare.Shared, -1);
                                    int num24 = 1;
                                    do
                                    {
                                        str3 = FileSystem.LineInput(2);
                                        num24 = checked(num24 + 1);
                                    }
                                    while (num24 <= 8);
                                    this.GrahBhog(MDLKundali.t);
                                    numArray = new int[] { 2 };
                                    FileSystem.FileClose(numArray);
                                    int num25 = 0;
                                    do
                                    {
                                        single9 = (float)((double)MDLKundali.bho[num25] - MDLKundali.ayan);
                                        single = this.FnRed(ref single9);
                                        int num26 = checked((int)Math.Round((double)((float)((float)Math.Floor((double)(single / 30f)) + 1f))));
                                        if (num25 == 0)
                                        {
                                            num3 = num26;
                                            lin = Conversion.Str(num3).Substring(1);
                                        }
                                        num = checked(checked(num26 - num3) + 1);
                                        if (num < 1)
                                        {
                                            num = checked(num + 12);
                                        }
                                        if (num25 > 0)
                                        {
                                            lin = string.Concat(lin, "#", Conversion.Str(num).Substring(1));
                                        }
                                        str2 = MDLKundali.grah[num25];
                                        num4 = (double)single;
                                        string str10 = this.RDMS(ref num4);
                                        single = (float)num4;
                                        str3 = str10;
                                        if (num25 == 0)
                                        {
                                            stringBuilder = new StringBuilder(string.Concat("-", str3.Substring(Math.Max(checked(str3.Length - 8), 0))));
                                        }
                                        if (num25 > 0)
                                        {
                                            stringBuilder.Append(string.Concat("#", str3.Substring(Math.Max(checked(str3.Length - 8), 0))));
                                        }
                                        num25 = checked(num25 + 1);
                                    }
                                    while (num25 <= 12);
                                    float single14 = (float)Math.Cos((double)single12);
                                    float single15 = (float)(Math.Tan((double)single2) * Math.Tan((double)single11));
                                    num23 = 0;
                                    ref double numPointer = ref MDLKundali.d2r;
                                    num4 = (double)single11;
                                    float single16 = this.Ra2Longi(ref single12, ref MDLKundali.r2d, ref num23, ref numPointer, ref num4);
                                    single11 = (float)num4;
                                    MDLKundali.cusp[10] = single16;
                                    double num27 = 20;
                                    int num28 = 40;
                                    num20 = 3;
                                    num21 = 0;
                                    float[] singleArray = MDLKundali.cusp;
                                    ref double numPointer1 = ref MDLKundali.r2d;
                                    num4 = (double)single11;
                                    float single17 = this.CHORD(ref num20, ref num28, ref num21, ref num1, ref MDLKundali.d2r, ref single15, ref single12, ref num27, ref numPointer1, ref num23, ref num4);
                                    single11 = (float)num4;
                                    singleArray[11] = single17;
                                    num27 = 50;
                                    num28 = 70;
                                    num20 = 1.5;
                                    float[] singleArray1 = MDLKundali.cusp;
                                    ref double numPointer2 = ref MDLKundali.r2d;
                                    num4 = (double)single11;
                                    float single18 = this.CHORD(ref num20, ref num28, ref num21, ref num1, ref MDLKundali.d2r, ref single15, ref single12, ref num27, ref numPointer2, ref num23, ref num4);
                                    single11 = (float)num4;
                                    singleArray1[12] = single18;
                                    if (!(single2 == 0f | (double)single12 == MDLKundali.pi / 2 | (double)single12 == MDLKundali.pi * 1.5))
                                    {
                                        num23 = -Math.Tan((double)single12) - (double)(1f / (single15 * single14));
                                        num23 = MDLKundali.r2d * Math.Atan(num23);
                                        if (num23 < 0)
                                        {
                                            num23 += 180;
                                        }
                                    }
                                    else
                                    {
                                        num23 = 90;
                                    }
                                    ref double numPointer3 = ref MDLKundali.d2r;
                                    num4 = (double)single11;
                                    float single19 = this.Ra2Longi(ref single12, ref MDLKundali.r2d, ref num23, ref numPointer3, ref num4);
                                    single11 = (float)num4;
                                    MDLKundali.cusp[1] = single19;
                                    if (lagan < 500f)
                                    {
                                        MDLKundali.cusp[1] = single1;
                                    }
                                    num27 = 110;
                                    num28 = 130;
                                    num20 = 1.5;
                                    num21 = 90;
                                    float[] singleArray2 = MDLKundali.cusp;
                                    ref double numPointer4 = ref MDLKundali.r2d;
                                    num4 = (double)single11;
                                    float single20 = this.CHORD(ref num20, ref num28, ref num21, ref num1, ref MDLKundali.d2r, ref single15, ref single12, ref num27, ref numPointer4, ref num23, ref num4);
                                    single11 = (float)num4;
                                    singleArray2[2] = single20;
                                    num27 = 140;
                                    num28 = 160;
                                    num20 = 3;
                                    num21 = 0;
                                    float[] singleArray3 = MDLKundali.cusp;
                                    ref double numPointer5 = ref MDLKundali.r2d;
                                    num4 = (double)single11;
                                    float single21 = this.CHORD(ref num20, ref num28, ref num21, ref num1, ref MDLKundali.d2r, ref single15, ref single12, ref num27, ref numPointer5, ref num23, ref num4);
                                    single11 = (float)num4;
                                    singleArray3[3] = single21;
                                    int num29 = 4;
                                    do
                                    {
                                        double num30 = (double)(checked(num29 + 6));
                                        if (num30 > 12)
                                        {
                                            num30 -= 12;
                                        }
                                        single9 = MDLKundali.cusp[checked((int)Math.Round(num30))] + 180f;
                                        MDLKundali.cusp[num29] = this.FnRed(ref single9);
                                        num29 = checked(num29 + 1);
                                    }
                                    while (num29 <= 9);
                                    lin = string.Concat(lin, "-", Conversion.Str(num3).Substring(1));
                                    int num31 = 1;
                                    do
                                    {
                                        MDLKundali.bhav[num31] = 0;
                                        num = 1;
                                        do
                                        {
                                            double num32 = (double)(checked(num + 1));
                                            if (num32 == 13)
                                            {
                                                num32 = 1;
                                            }
                                            single9 = MDLKundali.bho[num31] - MDLKundali.cusp[num];
                                            num23 = (double)this.FnRed(ref single9);
                                            single9 = MDLKundali.cusp[checked((int)Math.Round(num32))] - MDLKundali.cusp[num];
                                            if (num23 < (double)this.FnRed(ref single9))
                                            {
                                                MDLKundali.bhav[num31] = num;
                                                lin = string.Concat(lin, "#", Conversion.Str(num).Substring(1));
                                            }
                                            num = checked(num + 1);
                                        }
                                        while (num <= 12);
                                        num31 = checked(num31 + 1);
                                    }
                                    while (num31 <= 12);
                                    int num33 = 1;
                                    do
                                    {
                                        str1 = Conversions.ToString(Interaction.IIf(num33 == 1, "-", "#"));
                                        str2 = MDLKundali.bhava[num33];
                                        single9 = (float)((double)MDLKundali.cusp[num33] - MDLKundali.ayan);
                                        single = this.FnRed(ref single9);
                                        num2 = checked((int)Math.Round((double)((float)(1f + (float)Math.Floor((double)(single / 30f))))));
                                        lin = string.Concat(lin, str1, Conversion.Str(num2).Substring(1));
                                        num4 = (double)single;
                                        string str11 = this.RDMS(ref num4);
                                        single = (float)num4;
                                        str3 = str11;
                                        stringBuilder.Append(string.Concat(str1, str3.Substring(Math.Max(checked(str3.Length - 8), 0))));
                                        num33 = checked(num33 + 1);
                                    }
                                    while (num33 <= 12);
                                    lin = string.Concat(lin, "-");
                                    single9 = (float)((double)MDLKundali.bho[2] - MDLKundali.ayan);
                                    single = this.FnRed(ref single9);
                                    num2 = checked((int)Math.Round((double)((float)(1f + (float)Math.Floor((double)(single / 30f))))));
                                    lin = string.Concat(lin, Conversion.Str(num2).Substring(1));
                                    num2 = checked((int)Math.Round((double)((float)(1f + (float)Math.Floor((double)(single * 3f / 40f))))));
                                    lin = string.Concat(lin, "#", Conversion.Str(num2).Substring(1));
                                    num2 = checked((int)Math.Round(1 + Math.Floor((double)single * 0.3)));
                                    num2 %= 4;
                                    if (num2 == 0)
                                    {
                                        num2 = 4;
                                    }
                                    lin = string.Concat(lin, "#", Conversion.Str(num2).Substring(1));
                                    str = string.Concat(lin, stringBuilder.ToString());
                                    return str;
                                }
                                else
                                {
                                    str8 = string.Concat(str8, "Invalid Hour");
                                }
                            }
                            else
                            {
                                str8 = string.Concat(str8, "Invalid Day");
                            }
                        }
                        else
                        {
                            str8 = string.Concat(str8, "Invalid Month");
                        }
                    }
                    else
                    {
                        str8 = string.Concat(str8, "Invalid Time Zone");
                    }
                }
                else
                {
                    str8 = string.Concat(str8, "Invalid Longitude");
                }
            }
            else
            {
                str8 = string.Concat(str8, "Invalid Latitude");
            }
            str = str8;
            return str;
        }

        private double GEO(ref double r2d, ref double L0, ref double L1, ref double t, ref double B0, ref double B1, ref double R0, ref double r1, ref double d2r, ref float ert, ref double Se)
        {
            float single = (float)(r2d * (L0 + L1 * t) * 1E-08);
            double num = (double)this.FnRed(ref single);
            double b0 = (B0 + B1 * t) * 1E-08;
            double r0 = (R0 + r1 * t) * 1E-08;
            double num1 = r0 * Math.Cos(b0) * Math.Cos(d2r * num) - Se * Math.Cos(d2r * (double)ert);
            double num2 = r0 * Math.Cos(b0) * Math.Sin(d2r * num) - Se * Math.Sin(d2r * (double)ert);
            if (Math.Abs(num1) >= 1E-05)
            {
                num = r2d * Math.Atan(num2 / num1);
                if (num1 < 0)
                {
                    num += 180;
                }
            }
            else
            {
                num = (double)(checked(90 * Math.Sign(num2 / num1)));
            }
            return num;
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private void GrahBhog(double t)
        {
            double num = 0;
            double num1 = 0;
            double num2;
            double num3 = 0;
            double num4 = 0;
            double num5 = 0;
            double num6 = 0;
            double num7 = 0;
            string str = "";
            FileSystem.Input(2, ref str);
            double num8 = 0;
            double num9 = 1 - 0.002516 * t;
            float single = (float)(218.3164591 + 481267.88134236 * t - 0.0013268 * t * t);
            float single1 = this.FnRed(ref single);
            double num10 = MDLKundali.d2r;
            single = (float)(297.8502042 + 445267.1115168 * t - 0.00163 * t * t);
            double num11 = num10 * (double)this.FnRed(ref single);
            double num12 = MDLKundali.d2r;
            single = (float)(357.5291092 + 35999.0502909 * t - 0.0001536 * t * t);
            double num13 = num12 * (double)this.FnRed(ref single);
            double num14 = MDLKundali.d2r;
            single = (float)(134.9634114 + 477198.8676313 * t + 0.008997 * t * t);
            double num15 = num14 * (double)this.FnRed(ref single);
            double num16 = MDLKundali.d2r;
            single = (float)(93.2720993 + 483202.0175273 * t - 0.0034029 * t * t);
            double num17 = num16 * (double)this.FnRed(ref single);
            int num18 = 1;
            do
            {
                FileSystem.Input(2, ref num3);
                FileSystem.Input(2, ref num6);
                FileSystem.Input(2, ref num5);
                FileSystem.Input(2, ref num4);
                FileSystem.Input(2, ref num7);
                num2 = num7 * Math.Sin(num3 * num11 + num6 * num13 + num5 * num15 + num4 * num17);
                if (num6 != 0)
                {
                    num2 *= num9;
                    if (Math.Abs(num6) == 2)
                    {
                        num2 *= num9;
                    }
                }
                num8 += num2;
                num18 = checked(num18 + 1);
            }
            while (num18 <= 59);
            num8 = num8 + 3958 * Math.Sin(MDLKundali.d2r * (119.75 + 131.849 * t));
            num8 = num8 + 1962 * Math.Sin(MDLKundali.d2r * (double)single1 - num17);
            num8 = num8 + 318 * Math.Sin(MDLKundali.d2r * (53.09 + 479264.29 * t));
            float single2 = 0.1f;
            single = (float)((double)single1 + num8 * 1E-06 - 0.00166666666666667);
            single1 = this.FnRed(ref single) - single2;
            single = (float)(125.04452 - 1934.136261 * t);
            float single3 = this.FnRed(ref single) - single2;
            single = single3 + 180f;
            float single4 = this.FnRed(ref single);
            MDLKundali.bho[2] = single1;
            MDLKundali.bho[8] = single3;
            MDLKundali.bho[9] = single4;
            FileSystem.Input(2, ref str);
            t /= 10;
            int num19 = 17;
            double num20 = this.TERMS(ref num19, ref t);
            num19 = 3;
            double num21 = this.TERMS(ref num19, ref t);
            single = (float)(MDLKundali.r2d * (num20 + num21 * t) * 1E-08);
            float single5 = this.FnRed(ref single);
            single = (float)((double)(single5 + 180f) - 0.00611111111111111);
            float single6 = this.FnRed(ref single);
            num19 = 3;
            double num22 = this.TERMS(ref num19, ref t);
            double num23 = 103019 * Math.Cos(1.10749 + 6283.07585 * t);
            double num24 = (num22 + num23 * t) * 1E-08;
            MDLKundali.bho[1] = single6;
            FileSystem.Input(2, ref str);
            num19 = 7;
            num20 = this.TERMS(ref num19, ref t);
            num19 = 4;
            num21 = this.TERMS(ref num19, ref t);
            num19 = 4;
            double num25 = this.TERMS(ref num19, ref t);
            double num26 = 350069 * Math.Cos(5.368478 + 3340.612427 * t) - 14116;
            num19 = 4;
            num22 = this.TERMS(ref num19, ref t);
            num19 = 4;
            num23 = this.TERMS(ref num19, ref t);
            MDLKundali.bho[3] = (float)this.GEO(ref MDLKundali.r2d, ref num20, ref num21, ref t, ref num25, ref num26, ref num22, ref num23, ref MDLKundali.d2r, ref single5, ref num24);
            FileSystem.Input(2, ref str);
            num19 = 15;
            num20 = this.TERMS(ref num19, ref t);
            num19 = 7;
            num21 = this.TERMS(ref num19, ref t) + 53050 * t;
            num19 = 6;
            num25 = this.TERMS(ref num19, ref t);
            num26 = 429151 * Math.Cos(3.501698 + 26087.903142 * t) - 146234;
            num19 = 5;
            num22 = this.TERMS(ref num19, ref t);
            num19 = 3;
            num23 = this.TERMS(ref num19, ref t);
            MDLKundali.bho[4] = (float)this.GEO(ref MDLKundali.r2d, ref num20, ref num21, ref t, ref num25, ref num26, ref num22, ref num23, ref MDLKundali.d2r, ref single5, ref num24);
            FileSystem.Input(2, ref str);
            num19 = 11;
            num20 = this.TERMS(ref num19, ref t);
            num19 = 3;
            num21 = this.TERMS(ref num19, ref t);
            num19 = 3;
            num25 = this.TERMS(ref num19, ref t);
            num26 = 177352 * Math.Cos(5.701665 + 529.690965 * t);
            num19 = 5;
            num22 = this.TERMS(ref num19, ref t);
            num19 = 4;
            num23 = this.TERMS(ref num19, ref t);
            MDLKundali.bho[5] = (float)this.GEO(ref MDLKundali.r2d, ref num20, ref num21, ref t, ref num25, ref num26, ref num22, ref num23, ref MDLKundali.d2r, ref single5, ref num24);
            FileSystem.Input(2, ref str);
            num19 = 3;
            num20 = this.TERMS(ref num19, ref t);
            num19 = 3;
            num21 = this.TERMS(ref num19, ref t);
            num25 = 5923638 * Math.Cos(0.2670278 + 10213.2855462 * t);
            num25 = num25 + 40108 * Math.Cos(1.14737 + 20426.57109 * t) - 32815;
            num26 = 513348 * Math.Cos(1.803643 + 10213.285546 * t);
            num22 = 72334821 + 489824 * Math.Cos(4.021518 + 10213.285546 * t);
            num23 = 34551 * Math.Cos(0.89199 + 10213.28555 * t);
            MDLKundali.bho[6] = (float)this.GEO(ref MDLKundali.r2d, ref num20, ref num21, ref t, ref num25, ref num26, ref num22, ref num23, ref MDLKundali.d2r, ref single5, ref num24);
            FileSystem.Input(2, ref str);
            num19 = 8;
            num20 = this.TERMS(ref num19, ref t);
            num19 = 5;
            num21 = this.TERMS(ref num19, ref t);
            num19 = 6;
            num25 = this.TERMS(ref num19, ref t);
            num26 = 397555 * Math.Cos(5.3329 + 213.299095 * t) - 49479;
            num19 = 10;
            num22 = this.TERMS(ref num19, ref t);
            num23 = 6182981 * Math.Cos(0.2584352 + 213.2990954 * t);
            MDLKundali.bho[7] = (float)this.GEO(ref MDLKundali.r2d, ref num20, ref num21, ref t, ref num25, ref num26, ref num22, ref num23, ref MDLKundali.d2r, ref single5, ref num24);
            FileSystem.Input(2, ref str);
            num19 = 9;
            num20 = this.TERMS(ref num19, ref t);
            num19 = 3;
            num21 = this.TERMS(ref num19, ref t);
            num25 = 1346278 * Math.Cos(2.6187781 + 74.7815986 * t);
            num25 = num25 + 62341 * Math.Cos(5.08111 + 149.5632 * t) - 61601;
            num26 = 206366 * Math.Cos(4.123943 + 74.781599 * t);
            num19 = 4;
            num22 = this.TERMS(ref num19, ref t);
            num23 = 1479896 * Math.Cos(3.6720571 + 74.7815986 * t);
            MDLKundali.bho[10] = (float)this.GEO(ref MDLKundali.r2d, ref num20, ref num21, ref t, ref num25, ref num26, ref num22, ref num23, ref MDLKundali.d2r, ref single5, ref num24);
            FileSystem.Input(2, ref str);
            num19 = 8;
            num20 = this.TERMS(ref num19, ref t);
            num21 = 3837687717 + 16604 * Math.Cos(4.86319 + 1.48447 * t);
            num21 = num21 + 15807 * Math.Cos(2.27923 + 38.13304 * t);
            num19 = 5;
            num25 = this.TERMS(ref num19, ref t);
            num26 = 227279 * Math.Cos(3.807931 + 38.133036 * t);
            num19 = 10;
            num22 = this.TERMS(ref num19, ref t);
            num23 = 236339 * Math.Cos(0.70498 + 38.133036 * t);
            MDLKundali.bho[11] = (float)this.GEO(ref MDLKundali.r2d, ref num20, ref num21, ref t, ref num25, ref num26, ref num22, ref num23, ref MDLKundali.d2r, ref single5, ref num24);
            FileSystem.Input(2, ref str);
            t *= 10;
            double num27 = MDLKundali.d2r * (34.35 + 3034.9057 * t);
            double num28 = MDLKundali.d2r * (50.08 + 1222.1138 * t);
            double num29 = MDLKundali.d2r * (238.96 + 144.96 * t);
            num20 = 0;
            num25 = 0;
            num22 = 0;
            int num30 = 1;
            do
            {
                FileSystem.Input(2, ref num);
                FileSystem.Input(2, ref num1);
                FileSystem.Input(2, ref num2);
                double num31 = num * num27 + num1 * num28 + num2 * num29;
                FileSystem.Input(2, ref num);
                FileSystem.Input(2, ref num1);
                num20 = num20 + num * Math.Sin(num31) + num1 * Math.Cos(num31);
                FileSystem.Input(2, ref num);
                FileSystem.Input(2, ref num1);
                num25 = num25 + num * Math.Sin(num31) + num1 * Math.Cos(num31);
                FileSystem.Input(2, ref num);
                FileSystem.Input(2, ref num1);
                num22 = num22 + num * Math.Sin(num31) + num1 * Math.Cos(num31);
                num30 = checked(num30 + 1);
            }
            while (num30 <= 15);
            single = (float)(238.956785 + 144.96 * t + num20 * 1E-06 - 23.8565 + MDLKundali.ayan);
            double num32 = (double)this.FnRed(ref single);
            num1 = MDLKundali.d2r * (-3.908202 + num25 * 1E-06);
            double num33 = 40.7247248 + num22 * 1E-07;
            MDLKundali.bho[12] = (float)this.F_560(ref MDLKundali.r2d, ref num33, ref num1, ref num32, ref MDLKundali.d2r, ref single5, ref num24);
        }

        [SupportedOSPlatform("windows")]
        public WinDrawing.Bitmap KunImage(string kvlagna, List<KundliMappingVO> lkmv, string Online_Result, bool Bhav_Chalit, int Kund_Size, string lang)
        {
            long num = 0L;
            byte ghar = 0;
            byte num1;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            string[] strArrays = new string[14];
            string[] strArrays1 = new string[14];
            string[] strArrays2 = new string[13];
            string[] strArrays3 = new string[13];
            string[] strArrays4 = new string[14];
            int num5 = Convert.ToByte(kvlagna);
            WinDrawing.Bitmap bitmap = new WinDrawing.Bitmap(1, 1);
            WinDrawing.Graphics graphic = WinDrawing.Graphics.FromImage(bitmap);
            object obj = 0;
            MDLKundali.PosInKundli[] posInKundliArray = new MDLKundali.PosInKundli[13];
            MDLKundali.PosInKundli[,] posInKundliArray1 = new MDLKundali.PosInKundli[13, 13];
            WinDrawing.Rectangle rectangle = new WinDrawing.Rectangle();
            WinDrawing.SolidBrush solidBrush = new WinDrawing.SolidBrush(WinDrawing.Color.White);
            if (Kund_Size == 1)
            {
                num = (long)13;
            }
            if ((double)Kund_Size == 1.5)
            {
                num = (long)10;
            }
            if (Kund_Size == 2)
            {
                num = (long)8;
            }
            object font = new WinDrawing.Font("Tahoma", (float)num, WinDrawing.FontStyle.Bold, WinDrawing.GraphicsUnit.Point);
            byte num6 = 0;
            byte num7 = 0;
            int num8 = checked((int)Math.Round(520 / (double)Kund_Size));
            int num9 = checked((int)Math.Round(260 / (double)Kund_Size));
            WinDrawing.Font font1 = new WinDrawing.Font("Tahoma", (float)num, WinDrawing.FontStyle.Bold, WinDrawing.GraphicsUnit.Point);
            WinDrawing.Font font2 = new WinDrawing.Font("Tahoma", (float)num, WinDrawing.FontStyle.Bold, WinDrawing.GraphicsUnit.Point);
            int num10 = checked((int)Math.Round(Math.Round((double)num8 / 2)));
            int num11 = checked((int)Math.Round(Math.Round((double)num9 / 2)));
            bitmap = new WinDrawing.Bitmap(bitmap, new WinDrawing.Size(num8, num9));
            graphic = WinDrawing.Graphics.FromImage(bitmap);
            graphic.Clear(WinDrawing.Color.White);
            float single = (float)((double)num8 / 20);
            float single1 = (float)((double)num9 / 20);
            WinDrawing.Pen pen = new WinDrawing.Pen(WinDrawing.Color.Black)
            {
                Width = 2f
            };
            rectangle.X = num6;
            rectangle.Y = num7;
            rectangle.Width = num8;
            rectangle.Height = num9;
            graphic.DrawRectangle(pen, rectangle);
            graphic.DrawLine(pen, (int)num6, (int)num7, num8, num9);
            graphic.DrawLine(pen, (int)num6, num9, num8, (int)num7);
            graphic.DrawLine(pen, (int)num6, num11, num10, (int)num7);
            graphic.DrawLine(pen, num10, (int)num7, num8, num11);
            graphic.DrawLine(pen, (int)num6, num11, num10, num9);
            graphic.DrawLine(pen, num10, num9, num8, num11);
            solidBrush.Color = WinDrawing.Color.Black;
            graphic.DrawString("", (WinDrawing.Font)font, solidBrush, (float)((double)num10 - (double)single * 1.5), (float)num11 - single1);
            posInKundliArray[1].x = 9;
            posInKundliArray[1].y = 4;
            posInKundliArray1[1, 1].x = 9;
            posInKundliArray1[1, 1].y = 6;
            posInKundliArray1[1, 2].x = 9;
            posInKundliArray1[1, 2].y = 2;
            posInKundliArray1[1, 3].x = 11;
            posInKundliArray1[1, 3].y = 3;
            posInKundliArray1[1, 4].x = 11;
            posInKundliArray1[1, 4].y = 6;
            posInKundliArray1[1, 5].x = 7;
            posInKundliArray1[1, 5].y = 6;
            posInKundliArray1[1, 6].x = 7;
            posInKundliArray1[1, 6].y = 4;
            posInKundliArray1[1, 7].x = 6;
            posInKundliArray1[1, 7].y = 5;
            posInKundliArray1[1, 8].x = 8;
            posInKundliArray1[1, 8].y = 8;
            posInKundliArray1[1, 9].x = 10;
            posInKundliArray1[1, 9].y = 5;
            posInKundliArray1[1, 10].x = 12;
            posInKundliArray1[1, 10].y = 5;
            posInKundliArray1[1, 11].x = 9;
            posInKundliArray1[1, 11].y = 8;
            posInKundliArray1[1, 12].x = 10;
            posInKundliArray1[1, 12].y = 7;
            posInKundliArray[2].x = 4;
            posInKundliArray[2].y = 3;
            posInKundliArray1[2, 1].x = 4;
            posInKundliArray1[2, 1].y = 1;
            posInKundliArray1[2, 2].x = 6;
            posInKundliArray1[2, 2].y = 1;
            posInKundliArray1[2, 3].x = 2;
            posInKundliArray1[2, 3].y = 1;
            posInKundliArray1[2, 4].x = 5;
            posInKundliArray1[2, 4].y = 2;
            posInKundliArray1[2, 5].x = 3;
            posInKundliArray1[2, 5].y = 2;
            posInKundliArray1[2, 6].x = 5;
            posInKundliArray1[2, 6].y = 0;
            posInKundliArray1[2, 7].x = 3;
            posInKundliArray1[2, 7].y = 0;
            posInKundliArray1[2, 8].x = 1;
            posInKundliArray1[2, 8].y = 0;
            posInKundliArray1[2, 9].x = 7;
            posInKundliArray1[2, 9].y = 0;
            posInKundliArray1[2, 10].x = 5;
            posInKundliArray1[2, 10].y = 3;
            posInKundliArray1[2, 11].x = 5;
            posInKundliArray1[2, 11].y = 1;
            posInKundliArray1[2, 12].x = 3;
            posInKundliArray1[2, 12].y = 1;
            posInKundliArray[3].x = 3;
            posInKundliArray[3].y = 5;
            posInKundliArray1[3, 1].x = 1;
            posInKundliArray1[3, 1].y = 5;
            posInKundliArray1[3, 2].x = 1;
            posInKundliArray1[3, 2].y = 3;
            posInKundliArray1[3, 3].x = 1;
            posInKundliArray1[3, 3].y = 7;
            posInKundliArray1[3, 4].x = 0;
            posInKundliArray1[3, 4].y = 4;
            posInKundliArray1[3, 5].x = 0;
            posInKundliArray1[3, 5].y = 6;
            posInKundliArray1[3, 6].x = 0;
            posInKundliArray1[3, 6].y = 2;
            posInKundliArray1[3, 7].x = 0;
            posInKundliArray1[3, 7].y = 8;
            posInKundliArray1[3, 8].x = 2;
            posInKundliArray1[3, 8].y = 4;
            posInKundliArray1[3, 9].x = 2;
            posInKundliArray1[3, 9].y = 6;
            posInKundliArray1[3, 10].x = 0;
            posInKundliArray1[3, 10].y = 3;
            posInKundliArray1[3, 11].x = 0;
            posInKundliArray1[3, 11].y = 5;
            posInKundliArray1[3, 12].x = 0;
            posInKundliArray1[3, 12].y = 7;
            if (!Operators.ConditionalCompareObjectEqual(obj, 1, false))
            {
                MDLKundali.THouse[1].PlanetsInHouse = 0;
                MDLKundali.THouse[2].PlanetsInHouse = 0;
                MDLKundali.THouse[3].PlanetsInHouse = 0;
            }
            else
            {
                MDLKundali.QHouse[1].PlanetsInHouse = 0;
                MDLKundali.QHouse[2].PlanetsInHouse = 0;
                MDLKundali.QHouse[3].PlanetsInHouse = 0;
            }
            byte num12 = 4;
            do
            {
                if (num12 == 4 | num12 == 7 | num12 == 10)
                {
                    num4 = 1;
                }
                if (num12 == 5 | num12 == 9 | num12 == 11)
                {
                    num4 = 3;
                }
                if (num12 == 6 | num12 == 8 | num12 == 12)
                {
                    num4 = 2;
                }
                switch (num12)
                {
                    case 4:
                        {
                            num2 = -5;
                            num3 = 5;
                            break;
                        }
                    case 5:
                        {
                            num2 = 0;
                            num3 = 10;
                            break;
                        }
                    case 6:
                        {
                            num2 = 0;
                            num3 = 0;
                            break;
                        }
                    case 7:
                        {
                            num2 = 0;
                            num3 = 10;
                            break;
                        }
                    case 8:
                        {
                            num2 = 10;
                            num3 = 0;
                            break;
                        }
                    case 9:
                        {
                            num2 = 0;
                            num3 = 10;
                            break;
                        }
                    case 10:
                        {
                            num2 = 5;
                            num3 = 5;
                            break;
                        }
                    case 11:
                        {
                            num2 = 0;
                            num3 = 0;
                            break;
                        }
                    case 12:
                        {
                            num2 = 10;
                            num3 = 0;
                            break;
                        }
                }
                posInKundliArray[num12].x = checked((byte)(checked(posInKundliArray[num4].x + num2)));
                posInKundliArray[num12].y = checked((byte)(checked(posInKundliArray[num4].y + num3)));
                num1 = 1;
                do
                {
                    posInKundliArray1[num12, num1].x = checked((byte)(checked(posInKundliArray1[num4, num1].x + num2)));
                    posInKundliArray1[num12, num1].y = checked((byte)(checked(posInKundliArray1[num4, num1].y + num3)));
                    //num1 = (void*)(checked((byte)(num1 + 1)));
                    num1 = (checked((byte)(num1 + 1)));
                }
                while (num1 <= 12);
                if (num12 == 6 | num12 == 8)
                {
                    posInKundliArray[num12].y = checked((byte)(checked(19 - posInKundliArray[num12].y)));
                    num1 = 1;
                    do
                    {
                        posInKundliArray1[num12, num1].y = checked((byte)(checked(19 - posInKundliArray1[num12, num1].y)));
                        //num1 = (void*)(checked((byte)(num1 + 1)));
                        num1 = (checked((byte)(num1 + 1)));
                    }
                    while (num1 <= 12);
                }
                if (num12 == 9 | num12 == 11)
                {
                    posInKundliArray[num12].x = checked((byte)(checked(19 - posInKundliArray[num12].x)));
                    num1 = 1;
                    do
                    {
                        posInKundliArray1[num12, num1].x = checked((byte)(checked(19 - posInKundliArray1[num12, num1].x)));
                        //num1 = (void*)(checked((byte)(num1 + 1)));
                        num1 = (checked((byte)(num1 + 1)));
                    }
                    while (num1 <= 12);
                }
                if (!Operators.ConditionalCompareObjectEqual(obj, 1, false))
                {
                    MDLKundali.THouse[num12].PlanetsInHouse = 0;
                }
                else
                {
                    MDLKundali.QHouse[num12].PlanetsInHouse = 0;
                }
                //num12 = (void*)(checked((byte)(num12 + 1)));
                num12 = (checked((byte)(num12 + 1)));
            }
            while (num12 <= 12);
            byte num13 = Conversions.ToByte(kvlagna);
            num5 = num13;
            if (Bhav_Chalit)
            {
                char[] chrArray = new char[] { '-' };
                string[] strArrays5 = Online_Result.Split(chrArray);
                string str = strArrays5[0];
                chrArray = new char[] { '#' };
                strArrays = str.Split(chrArray);
                string str1 = strArrays5[1];
                chrArray = new char[] { '#' };
                strArrays1 = str1.Split(chrArray);
                string str2 = strArrays5[2];
                chrArray = new char[] { '#' };
                strArrays2 = str2.Split(chrArray);
                MDLKundali.QPlanet[1].Postion = Conversions.ToSingle(strArrays1[1]);
                MDLKundali.QPlanet[1].Ghar = Conversions.ToInteger(strArrays1[1]);
                MDLKundali.QPlanet[1].Rashi = Conversions.ToByte(strArrays2[checked((int)Math.Round(Conversions.ToDouble(strArrays1[1]) - 1))]);
                MDLKundali.QPlanet[1].isBad = false;
                MDLKundali.QPlanet[2].Postion = Conversions.ToSingle(strArrays1[2]);
                MDLKundali.QPlanet[2].Ghar = Conversions.ToInteger(strArrays1[2]);
                MDLKundali.QPlanet[2].Rashi = Conversions.ToByte(strArrays2[checked((int)Math.Round(Conversions.ToDouble(strArrays1[2]) - 1))]);
                MDLKundali.QPlanet[2].isBad = false;
                MDLKundali.QPlanet[3].Postion = Conversions.ToSingle(strArrays1[3]);
                MDLKundali.QPlanet[3].Ghar = Conversions.ToInteger(strArrays1[3]);
                MDLKundali.QPlanet[3].Rashi = Conversions.ToByte(strArrays2[checked((int)Math.Round(Conversions.ToDouble(strArrays1[3]) - 1))]);
                MDLKundali.QPlanet[3].isBad = false;
                MDLKundali.QPlanet[4].Postion = Conversions.ToSingle(strArrays1[4]);
                MDLKundali.QPlanet[4].Ghar = Conversions.ToInteger(strArrays1[4]);
                MDLKundali.QPlanet[4].Rashi = Conversions.ToByte(strArrays2[checked((int)Math.Round(Conversions.ToDouble(strArrays1[4]) - 1))]);
                MDLKundali.QPlanet[4].isBad = false;
                MDLKundali.QPlanet[5].Postion = Conversions.ToSingle(strArrays1[5]);
                MDLKundali.QPlanet[5].Ghar = Conversions.ToInteger(strArrays1[5]);
                MDLKundali.QPlanet[5].Rashi = Conversions.ToByte(strArrays2[checked((int)Math.Round(Conversions.ToDouble(strArrays1[5]) - 1))]);
                MDLKundali.QPlanet[5].isBad = false;
                MDLKundali.QPlanet[6].Postion = Conversions.ToSingle(strArrays1[6]);
                MDLKundali.QPlanet[6].Ghar = Conversions.ToInteger(strArrays1[6]);
                MDLKundali.QPlanet[6].Rashi = Conversions.ToByte(strArrays2[checked((int)Math.Round(Conversions.ToDouble(strArrays1[6]) - 1))]);
                MDLKundali.QPlanet[6].isBad = false;
                MDLKundali.QPlanet[7].Postion = Conversions.ToSingle(strArrays1[7]);
                MDLKundali.QPlanet[7].Ghar = Conversions.ToInteger(strArrays1[7]);
                MDLKundali.QPlanet[7].Rashi = Conversions.ToByte(strArrays2[checked((int)Math.Round(Conversions.ToDouble(strArrays1[7]) - 1))]);
                MDLKundali.QPlanet[7].isBad = false;
                MDLKundali.QPlanet[8].Postion = Conversions.ToSingle(strArrays1[8]);
                MDLKundali.QPlanet[8].Ghar = Conversions.ToInteger(strArrays1[8]);
                MDLKundali.QPlanet[8].Rashi = Conversions.ToByte(strArrays2[checked((int)Math.Round(Conversions.ToDouble(strArrays1[8]) - 1))]);
                MDLKundali.QPlanet[8].isBad = false;
                MDLKundali.QPlanet[9].Postion = Conversions.ToSingle(strArrays1[9]);
                MDLKundali.QPlanet[9].Ghar = Conversions.ToInteger(strArrays1[9]);
                MDLKundali.QPlanet[9].Rashi = Conversions.ToByte(strArrays2[checked((int)Math.Round(Conversions.ToDouble(strArrays1[9]) - 1))]);
                MDLKundali.QPlanet[9].isBad = false;
            }
            else
            {
                MDLKundali.QPlanet[1].Postion = (float)lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Surya", false) == 0).House;
                MDLKundali.QPlanet[1].Rashi = checked((byte)lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Surya", false) == 0).Rashi);
                MDLKundali.QPlanet[1].Ghar = lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Surya", false) == 0).House;
                MDLKundali.QPlanet[1].isBad = lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Surya", false) == 0).IsBad;
                MDLKundali.QPlanet[2].Postion = (float)lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Chandra", false) == 0).House;
                MDLKundali.QPlanet[2].Rashi = checked((byte)lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Chandra", false) == 0).Rashi);
                MDLKundali.QPlanet[2].Ghar = lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Chandra", false) == 0).House;
                MDLKundali.QPlanet[2].isBad = lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Chandra", false) == 0).IsBad;
                MDLKundali.QPlanet[3].Postion = (float)lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Mangal", false) == 0).House;
                MDLKundali.QPlanet[3].Rashi = checked((byte)lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Mangal", false) == 0).Rashi);
                MDLKundali.QPlanet[3].Ghar = lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Mangal", false) == 0).House;
                MDLKundali.QPlanet[3].isBad = lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Mangal", false) == 0).IsBad;
                MDLKundali.QPlanet[4].Postion = (float)lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Budh", false) == 0).House;
                MDLKundali.QPlanet[4].Rashi = checked((byte)lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Budh", false) == 0).Rashi);
                MDLKundali.QPlanet[4].Ghar = lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Budh", false) == 0).House;
                MDLKundali.QPlanet[4].isBad = lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Budh", false) == 0).IsBad;
                MDLKundali.QPlanet[5].Postion = (float)lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Guru", false) == 0).House;
                MDLKundali.QPlanet[5].Rashi = checked((byte)lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Guru", false) == 0).Rashi);
                MDLKundali.QPlanet[5].Ghar = lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Guru", false) == 0).House;
                MDLKundali.QPlanet[5].isBad = lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Guru", false) == 0).IsBad;
                MDLKundali.QPlanet[6].Postion = (float)lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Shukra", false) == 0).House;
                MDLKundali.QPlanet[6].Rashi = checked((byte)lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Shukra", false) == 0).Rashi);
                MDLKundali.QPlanet[6].Ghar = lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Shukra", false) == 0).House;
                MDLKundali.QPlanet[6].isBad = lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Shukra", false) == 0).IsBad;
                MDLKundali.QPlanet[7].Postion = (float)lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Shani", false) == 0).House;
                MDLKundali.QPlanet[7].Rashi = checked((byte)lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Shani", false) == 0).Rashi);
                MDLKundali.QPlanet[7].Ghar = lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Shani", false) == 0).House;
                MDLKundali.QPlanet[7].isBad = lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Shani", false) == 0).IsBad;
                MDLKundali.QPlanet[8].Postion = (float)lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Rahu", false) == 0).House;
                MDLKundali.QPlanet[8].Rashi = checked((byte)lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Rahu", false) == 0).Rashi);
                MDLKundali.QPlanet[8].Ghar = lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Rahu", false) == 0).House;
                MDLKundali.QPlanet[8].isBad = lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Rahu", false) == 0).IsBad;
                MDLKundali.QPlanet[9].Postion = (float)lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Ketu", false) == 0).House;
                MDLKundali.QPlanet[9].Rashi = checked((byte)lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Ketu", false) == 0).Rashi);
                MDLKundali.QPlanet[9].Ghar = lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Ketu", false) == 0).House;
                MDLKundali.QPlanet[9].isBad = lkmv.Find((KundliMappingVO Map) => Operators.CompareString(Map.PlanetName, "Ketu", false) == 0).IsBad;
            }
            byte num14 = num13;
            num12 = 1;
            do
            {
                byte num15 = 0;
                num1 = (Bhav_Chalit ? Conversions.ToByte(strArrays2[checked(num12 - 1)]) : Conversions.ToByte(Interaction.IIf(checked(checked(num12 - 1) + num14) > 12, checked(checked(checked(num12 - 1) + num14) - 12), checked(checked(num12 - 1) + num14))));
                solidBrush.Color = WinDrawing.Color.Black;
                graphic.DrawString(Conversion.Str(num1), font1, solidBrush, (float)posInKundliArray[num12].x * single, (float)posInKundliArray[num12].y * single1);
                object obj1 = string.Concat(Conversion.Str(num1), "#");
                num1 = 1;
                do
                {
                    object obj2 = obj;
                    if (Operators.ConditionalCompareObjectEqual(obj2, 0, false))
                    {
                        ghar = checked((byte)MDLKundali.QPlanet[num1].Ghar);
                    }
                    else if (Operators.ConditionalCompareObjectEqual(obj2, 1, false))
                    {
                        ghar = MDLKundali.QPlanet[num1].MoonGhar;
                    }
                    else if (Operators.ConditionalCompareObjectEqual(obj2, 2, false))
                    {
                        ghar = MDLKundali.QPlanet[num1].HoraGhar;
                    }
                    else if (Operators.ConditionalCompareObjectEqual(obj2, 3, false))
                    {
                        ghar = MDLKundali.QPlanet[num1].DreskanGhar;
                    }
                    else if (Operators.ConditionalCompareObjectEqual(obj2, 4, false))
                    {
                        ghar = MDLKundali.QPlanet[num1].SaptmansGhar;
                    }
                    else if (Operators.ConditionalCompareObjectEqual(obj2, 5, false))
                    {
                        ghar = MDLKundali.QPlanet[num1].NavnansGhar;
                    }
                    else if (Operators.ConditionalCompareObjectEqual(obj2, 6, false))
                    {
                        ghar = MDLKundali.QPlanet[num1].DwadsansGhar;
                    }
                    else if (Operators.ConditionalCompareObjectEqual(obj2, 7, false))
                    {
                        ghar = MDLKundali.QPlanet[num1].TrisansGhar;
                    }
                    if (ghar == num12)
                    {
                        if (MDLKundali.QPlanet[num1].isBad)
                        {
                            solidBrush.Color = WinDrawing.Color.Black;
                            if (Operators.CompareString(lang.ToLower(), "hindi", false) != 0)
                            {
                                graphic.DrawString(MDLKundali.QPlanet[num1].pNameENG, font2, solidBrush, (float)posInKundliArray1[num12, checked(num15 + 1)].x * single, (float)posInKundliArray1[num12, checked(num15 + 1)].y * single1);
                            }
                            else
                            {
                                graphic.DrawString(MDLKundali.QPlanet[num1].pName, font2, solidBrush, (float)posInKundliArray1[num12, checked(num15 + 1)].x * single, (float)posInKundliArray1[num12, checked(num15 + 1)].y * single1);
                            }
                        }
                        if (!MDLKundali.QPlanet[num1].isBad)
                        {
                            solidBrush.Color = WinDrawing.Color.Black;
                            if (Operators.CompareString(lang.ToLower(), "hindi", false) != 0)
                            {
                                graphic.DrawString(MDLKundali.QPlanet[num1].pNameENG, font2, solidBrush, (float)posInKundliArray1[num12, checked(num15 + 1)].x * single, (float)posInKundliArray1[num12, checked(num15 + 1)].y * single1);
                            }
                            else
                            {
                                graphic.DrawString(MDLKundali.QPlanet[num1].pName, font2, solidBrush, (float)posInKundliArray1[num12, checked(num15 + 1)].x * single, (float)posInKundliArray1[num12, checked(num15 + 1)].y * single1);
                            }
                        }
                        obj1 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj1, Strings.Left(MDLKundali.QPlanet[num1].pName, 3)), "#");
                        num15 = checked((byte)(checked(num15 + 1)));
                    }
                    //num1 = (void*)(checked((byte)(num1 + 1)));
                    num1 = (checked((byte)(num1 + 1)));
                }
                while (num1 <= 9);
                if (Operators.ConditionalCompareObjectEqual(obj, 0, false))
                {
                    MDLKundali.QHouse[num12].PlanetsInHouse = num15;
                }
                //num12 = (void*)(checked((byte)(num12 + 1)));
                num12 = (checked((byte)(num12 + 1)));
            }
            while (num12 <= 12);
            pen.Dispose();
            solidBrush.Dispose();
            font1.Dispose();
            font2.Dispose();
            NewLateBinding.LateCall(font, null, "dispose", new object[0], null, null, null, true);
            graphic.Flush();
            return bitmap;
        }

        public Image KunImageCore(string kvlagna, List<KundliMappingVO> lkmv, string Online_Result, bool Bhav_Chalit, int Kund_Size, string lang)
        {
            using var image = new Image<Rgba32>(1, 1);

            image.Mutate(imageContext =>
            {

            });

            return image;
        }

        private float Ra2Longi(ref float zra, ref double r2d, ref double xx, ref double d2r, ref double inc)
        {
            double num;
            float single = (float)((double)zra * r2d + xx);
            double num1 = (double)this.FnRed(ref single);
            if (Math.Abs(num1 - 180) != 90)
            {
                num = r2d * Math.Atan(Math.Tan(num1 * d2r) / Math.Cos(inc));
                if (num1 > 90 & num1 < 270)
                {
                    num = 180 + num;
                }
                if (num1 > 270)
                {
                    num = 360 + num;
                }
            }
            else
            {
                num = (double)(checked(checked(Math.Sign(num1 - 180) * 90) + 180));
            }
            return (float)num;
        }

        private string RDMS(ref double bhog)
        {
            string str = null;
            double num = Math.Floor(bhog / 30);
            double num1 = Math.Floor(bhog - 30 * num);
            double num2 = Math.Floor(60 * (bhog - Math.Floor(bhog)));
            double num3 = (bhog - Math.Floor(bhog)) * 3600 - num2 * 60;
            if (num3 == 60)
            {
                num2 += 1;
                num3 = 0;
            }
            if (num2 == 60)
            {
                num1 += 1;
                num2 = 0;
            }
            if (num1 == 30)
            {
                num += 1;
                num1 = 0;
            }
            if (num == 12)
            {
                num = 0;
            }
            num += 1;
            string str1 = string.Concat(str, " ", MDLKundali.ras[checked((int)Math.Round(num))], " ");
            string[] strArrays = new string[] { str1, Conversion.Str(num1).Substring(Math.Max(checked(Conversion.Str(num1).Length - 2), 0)), ":", Conversion.Str(num2).Substring(Math.Max(checked(Conversion.Str(num2).Length - 2), 0)), ":" };
            str1 = string.Concat(strArrays);
            str1 = string.Concat(str1, Conversion.Str(num3).Substring(Math.Max(checked(Conversion.Str(num3).Length - 2), 0)));
            int length = str1.Length;
            if (num1 < 10)
            {
                StringType.MidStmtStr(ref str1, checked(length - 7), 2147483647, "0");
            }
            if (num2 < 10)
            {
                StringType.MidStmtStr(ref str1, checked(length - 4), 2147483647, "0");
            }
            if (num3 < 10)
            {
                StringType.MidStmtStr(ref str1, checked(length - 1), 2147483647, "0");
            }
            return str1;
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private double TERMS(ref int N, ref double t)
        {
            double num = 0;
            double num1 = 0;
            double num2 = 0;
            double num3 = 0;
            int n = N;
            for (int i = 1; i <= n; i = checked(i + 1))
            {
                FileSystem.Input(2, ref num);
                FileSystem.Input(2, ref num1);
                FileSystem.Input(2, ref num2);
                num3 = num3 + num * Math.Cos(num1 + num2 * t);
            }
            return num3;
        }
    }
}