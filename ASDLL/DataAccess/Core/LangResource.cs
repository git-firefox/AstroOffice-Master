using System;

namespace ASDLL.DataAccess.Core
{
    public class LangResource
    {
        public LangResource()
        {
        }

        public string getJadPrabhav(string lang, string mnths)
        {
            string str = "";
            if (lang.Equals("hindi"))
            {
                str = string.Concat(str, "AA fQj ", mnths, " osa ekg fuEufyf[kr mik; djsa AA");
            }
            else if (lang == "tamil")
            {
                str = string.Concat(str, "gpd;du;> ", mnths, " khjq;fSf;F gpd;tUk; gupfhuq;fs; kw;Wk; Kd;ndr;rupf;if eltbf;iffisr;  nra;aTk;.");
            }
            else if (lang == "bangla")
            {
                str = string.Concat(str, "a¡lfl ¢ejÀ¢m¢Ma fË¢aL¡l…¢m Hhw fË¡NÚ¢hd¡e…¢m ", mnths, " j¡­pl j¡­pl SeÉ f¡me ");
            }
            else if (lang == "telugu")
            {
                str = string.Concat(str, "‡ ~>·Te |Ÿ]VŸ²s\u0090\\qT", mnths, "  Hî\\T #ûjáT+&\u008d");
            }
            else if (lang == "kannada")
            {
                str = string.Concat(str, "£ÀAvÀgÀ, F PÉ¼ÀV£À ¥ÀjºÁgÀUÀ¼À£ÀÄß ªÀÄvÀÄÛ ªÀÄÄ£ÉßZÀÑjPÉUÀ¼À£ÀÄß ", mnths, " wAUÀ¼ÀªÀgÉUÉ ªÀiÁr");
            }
            else if (lang == "marathi")
            {
                str = string.Concat(str, "rqEgh", mnths, " efgU;ka lkBh [kkyhy mik; o lko/kkurk ikGk-");
            }
            else if (!(lang == "punjabi"))
            {
                str = (!(lang == "gujarati") ? string.Concat(str, "Then do the following remedies  for  ", mnths, "months : ") : string.Concat(str, " oÐÐê §ÐTúÕ  ", mnths, " ®ÐÑÅú¥ÐÐAÐê ®ÐÐcêú ¥ÐÕSÐê¥ÐÐ D§ÐÐ¯ÐÐê A¥Ðê ÁÐÐºÐSÐêoÐÕAÐê Kú³úÐê:"));
            }
            else
            {
                str = string.Concat(str, mnths, " mhInyAW leI hyT ilKy hIly qy bcwau vrqo :");
            }
            str = string.Concat(str, "\r\n");
            return str;
        }

        public string getJadPrabhavMonth(string lang, string from, string mnths)
        {
            string str;
            string[] strArrays;
            string str1 = "";
            if (lang.Equals("hindi"))
            {
                str = str1;
                strArrays = new string[] { str, "AA ", from, "osa o\"kZ ls ", mnths, "osa ekg fuEufyf[kr  mik; djsa AA" };
                str1 = string.Concat(strArrays);
            }
            else if (lang == "tamil")
            {
                str = str1;
                strArrays = new string[] { str, from, " tajpy; ,Ue;J> ", mnths, " khjq;fSf;F gpd;tUk; gupfhuq;fs; kw;Wk; Kd;ndr;rupf;if eltbf;iffisr;  nra;aTk;." };
                str1 = string.Concat(strArrays);
            }
            else if (lang == "bangla")
            {
                str = str1;
                strArrays = new string[] { str, from, " hRl hup ­b­L ¢ejÀ¢m¢Ma fË¢aL¡l…¢m Hhw fË¡NÚ¢hd¡e…¢m  ", mnths, " j¡­pl SeÉ f¡me " };
                str1 = string.Concat(strArrays);
            }
            else if (lang == "telugu")
            {
                str = str1;
                strArrays = new string[] { str, from, " dŸ+eÔáàs\u0090\\ ejáTdŸTà qT+º ‡ ~>·Te |Ÿ]VŸäs\u0090\\T eT]jáTT C²ç>·Ôáï\\qT ", mnths, " Hî\\bÍ³T bÍ{ì+#á+&\u008d." };
                str1 = string.Concat(strArrays);
            }
            else if (lang == "kannada")
            {
                str = str1;
                strArrays = new string[] { str, from, "£ÉÃ ªÀAiÀÄ¹ì¤AzÀ, F PÉ¼ÀV£À ¥ÀjºÁgÀUÀ¼À£ÀÄß ªÀÄvÀÄÛ ªÀÄÄ£ÉßZÀÑjPÉUÀ¼À£ÀÄß ", mnths, "wAUÀ¼ÀªÀgÉUÉ ªÀiÁr" };
                str1 = string.Concat(strArrays);
            }
            else if (lang == "marathi")
            {
                str = str1;
                strArrays = new string[] { str, "o;kP;k ", from, "O;k o”khZ [kkyhy mik; o lko/kkurk ", mnths, "efgU;ka lkBh djk-" };
                str1 = string.Concat(strArrays);
            }
            else if (lang == "punjabi")
            {
                str = str1;
                strArrays = new string[] { str, "quhwfI aumr dy  ", from, " vyN swl qoN sUru krky  ", mnths, " mhInyAW leI hyT ilKy hIly qy bcwau vrqo[" };
                str1 = string.Concat(strArrays);
            }
            else if (!(lang == "gujarati"))
            {
                str = str1;
                strArrays = new string[] { str, "From the age of ", from, " years, do the following remedies  for ", mnths, " months." };
                str1 = string.Concat(strArrays);
            }
            else
            {
                str = str1;
                strArrays = new string[] { str, from, " ºÐÀÐü¥ÐÕ Dð®Ð³úrÐÕ,  ", mnths, " ®ÐÑÅú¥ÐÐAÐê ®ÐÐcêú ¥ÐÕSÐê¥ÐÐ D§ÐÐ¯ÐÐê A¥Ðê ÁÐÐºÐSÐêoÐÕAÐê Kú³úÐê:" };
                str1 = string.Concat(strArrays);
            }
            str1 = string.Concat(str1, "\r\n");
            return str1;
        }

        public string getJadPrabhavYear(string lang, string from, string till)
        {
            string str;
            string[] strArrays;
            string str1 = "";
            if (lang.Equals("hindi"))
            {
                str = str1;
                strArrays = new string[] { str, "AA ", from, "osa ls ", till, "osa o\"kZ rd fuEufyf[kr  mik; djsa AA" };
                str1 = string.Concat(strArrays);
            }
            else if (lang == "tamil")
            {
                str = str1;
                strArrays = new string[] { str, from, "-", till, "taJ tiu gpd;tUk; gupfhuq;fs; kw;Wk; Kd;ndr;rupf;if eltbf;iffisr;  nra;aTk;." };
                str1 = string.Concat(strArrays);
            }
            else if (lang == "bangla")
            {
                str = str1;
                strArrays = new string[] { str, from, "-", till, " hRl fËk¸a ¢eÇe¢m¢Ma palLa¡ Hhw Ef¡u Ll¤e zz " };
                str1 = string.Concat(strArrays);
            }
            else if (lang == "telugu")
            {
                str = str1;
                strArrays = new string[] { str, from, " dŸ+eÔáàs\u0090\\ qT+º ", till, " dŸ+eÔáàs\u0090\\ ejáTdŸTà eT<óŠ« ‡ ~>·Te |Ÿ]VŸäs\u0090\\T eT]jáTT C²ç>·Ôáï\\qT bÍ{ì+#á+&\u008d." };
                str1 = string.Concat(strArrays);
            }
            else if (lang == "kannada")
            {
                str = str1;
                strArrays = new string[] { str, from, " jAzÀ", till, " ªÀµÀðUÀ¼À ªÀAiÀÄ¹ì£À°è F PÉ¼ÀV£À ¥ÀjºÁgÀUÀ¼À£ÀÄß ªÀÄvÀÄÛ ªÀÄÄ£ÉßZÀjPÉUÀ¼À£ÀÄß ¥Á°¹" };
                str1 = string.Concat(strArrays);
            }
            else if (lang == "marathi")
            {
                str = str1;
                strArrays = new string[] { str, "o;kP;k ", from, " rs ", till, " o”kkZ i;Zar [kkyhy mik; o lko/kkurk ikGk-  " };
                str1 = string.Concat(strArrays);
            }
            else if (lang == "punjabi")
            {
                str = str1;
                strArrays = new string[] { str, "quhwfI aumr dy  ", from, "-", till, " swlW iv~c hyT ilKy hIly qy bcwau vrqo : " };
                str1 = string.Concat(strArrays);
            }
            else if (!(lang == "gujarati"))
            {
                str = str1;
                strArrays = new string[] { str, "From the age of ", from, " to ", till, " years do the following remedies  : " };
                str1 = string.Concat(strArrays);
            }
            else
            {
                str = str1;
                strArrays = new string[] { str, from, "-", till, " ºÐÀÐü¥ÐÕ Dð®Ð³úrÐÕ ¥ÐÕSÐê¥ÐÐ D§ÐÐ¯ÐÐê A¥Ðê ÁÐÐºÐSÐêoÐÕAÐê Kú³úÐê:" };
                str1 = string.Concat(strArrays);
            }
            str1 = string.Concat(str1, "\r\n");
            return str1;
        }

        public string getPrabhav(long jad_prabhav_from, long umra, string lang)
        {
            string str;
            string[] strArrays;
            long jadPrabhavFrom;
            string str1 = "";
            if (lang.Equals("hindi"))
            {
                str = str1;
                strArrays = new string[] { str, jad_prabhav_from.ToString(), "&", null, null, null, null, null, null, null, null, null, null };
                jadPrabhavFrom = jad_prabhav_from + umra;
                strArrays[3] = jadPrabhavFrom.ToString();
                strArrays[4] = "] ";
                jadPrabhavFrom = jad_prabhav_from + (long)35;
                strArrays[5] = jadPrabhavFrom.ToString();
                strArrays[6] = "&";
                jadPrabhavFrom = jad_prabhav_from + (long)35 + umra;
                strArrays[7] = jadPrabhavFrom.ToString();
                strArrays[8] = "] ";
                jadPrabhavFrom = jad_prabhav_from + (long)70;
                strArrays[9] = jadPrabhavFrom.ToString();
                strArrays[10] = "&";
                jadPrabhavFrom = jad_prabhav_from + (long)70 + umra;
                strArrays[11] = jadPrabhavFrom.ToString();
                strArrays[12] = " ";
                str1 = string.Concat(strArrays);
            }
            else if (lang == "tamil")
            {
                str = str1;
                strArrays = new string[] { str, jad_prabhav_from.ToString(), " - ", null, null, null, null, null, null, null, null, null, null };
                jadPrabhavFrom = jad_prabhav_from + umra;
                strArrays[3] = jadPrabhavFrom.ToString();
                strArrays[4] = ", ";
                jadPrabhavFrom = jad_prabhav_from + (long)35;
                strArrays[5] = jadPrabhavFrom.ToString();
                strArrays[6] = " - ";
                jadPrabhavFrom = jad_prabhav_from + (long)35 + umra;
                strArrays[7] = jadPrabhavFrom.ToString();
                strArrays[8] = ", ";
                jadPrabhavFrom = jad_prabhav_from + (long)70;
                strArrays[9] = jadPrabhavFrom.ToString();
                strArrays[10] = " - ";
                jadPrabhavFrom = jad_prabhav_from + (long)70 + umra;
                strArrays[11] = jadPrabhavFrom.ToString();
                strArrays[12] = " ";
                str1 = string.Concat(strArrays);
            }
            else if (lang == "bangla")
            {
                str = str1;
                strArrays = new string[] { str, jad_prabhav_from.ToString(), " - ", null, null, null, null, null, null, null, null, null, null };
                jadPrabhavFrom = jad_prabhav_from + umra;
                strArrays[3] = jadPrabhavFrom.ToString();
                strArrays[4] = ", ";
                jadPrabhavFrom = jad_prabhav_from + (long)35;
                strArrays[5] = jadPrabhavFrom.ToString();
                strArrays[6] = " - ";
                jadPrabhavFrom = jad_prabhav_from + (long)35 + umra;
                strArrays[7] = jadPrabhavFrom.ToString();
                strArrays[8] = ", ";
                jadPrabhavFrom = jad_prabhav_from + (long)70;
                strArrays[9] = jadPrabhavFrom.ToString();
                strArrays[10] = " - ";
                jadPrabhavFrom = jad_prabhav_from + (long)70 + umra;
                strArrays[11] = jadPrabhavFrom.ToString();
                strArrays[12] = " ";
                str1 = string.Concat(strArrays);
            }
            else if (lang == "telugu")
            {
                str = str1;
                strArrays = new string[] { str, jad_prabhav_from.ToString(), " - ", null, null, null, null, null, null, null, null, null, null };
                jadPrabhavFrom = jad_prabhav_from + umra;
                strArrays[3] = jadPrabhavFrom.ToString();
                strArrays[4] = ", ";
                jadPrabhavFrom = jad_prabhav_from + (long)35;
                strArrays[5] = jadPrabhavFrom.ToString();
                strArrays[6] = " - ";
                jadPrabhavFrom = jad_prabhav_from + (long)35 + umra;
                strArrays[7] = jadPrabhavFrom.ToString();
                strArrays[8] = ", ";
                jadPrabhavFrom = jad_prabhav_from + (long)70;
                strArrays[9] = jadPrabhavFrom.ToString();
                strArrays[10] = " - ";
                jadPrabhavFrom = jad_prabhav_from + (long)70 + umra;
                strArrays[11] = jadPrabhavFrom.ToString();
                strArrays[12] = " ";
                str1 = string.Concat(strArrays);
            }
            else if (lang == "kannada")
            {
                str = str1;
                strArrays = new string[] { str, jad_prabhav_from.ToString(), " - ", null, null, null, null, null, null, null, null, null, null };
                jadPrabhavFrom = jad_prabhav_from + umra;
                strArrays[3] = jadPrabhavFrom.ToString();
                strArrays[4] = ", ";
                jadPrabhavFrom = jad_prabhav_from + (long)35;
                strArrays[5] = jadPrabhavFrom.ToString();
                strArrays[6] = " - ";
                jadPrabhavFrom = jad_prabhav_from + (long)35 + umra;
                strArrays[7] = jadPrabhavFrom.ToString();
                strArrays[8] = ", ";
                jadPrabhavFrom = jad_prabhav_from + (long)70;
                strArrays[9] = jadPrabhavFrom.ToString();
                strArrays[10] = " - ";
                jadPrabhavFrom = jad_prabhav_from + (long)70 + umra;
                strArrays[11] = jadPrabhavFrom.ToString();
                strArrays[12] = " ";
                str1 = string.Concat(strArrays);
            }
            else if (!lang.Equals("marathi"))
            {
                str = str1;
                strArrays = new string[] { str, jad_prabhav_from.ToString(), " - ", null, null, null, null, null, null, null, null, null, null };
                jadPrabhavFrom = jad_prabhav_from + umra;
                strArrays[3] = jadPrabhavFrom.ToString();
                strArrays[4] = ", ";
                jadPrabhavFrom = jad_prabhav_from + (long)35;
                strArrays[5] = jadPrabhavFrom.ToString();
                strArrays[6] = " - ";
                jadPrabhavFrom = jad_prabhav_from + (long)35 + umra;
                strArrays[7] = jadPrabhavFrom.ToString();
                strArrays[8] = ", ";
                jadPrabhavFrom = jad_prabhav_from + (long)70;
                strArrays[9] = jadPrabhavFrom.ToString();
                strArrays[10] = " - ";
                jadPrabhavFrom = jad_prabhav_from + (long)70 + umra;
                strArrays[11] = jadPrabhavFrom.ToString();
                strArrays[12] = " ";
                str1 = string.Concat(strArrays);
            }
            else
            {
                str = str1;
                strArrays = new string[] { str, jad_prabhav_from.ToString(), "&", null, null, null, null, null, null, null, null, null, null };
                jadPrabhavFrom = jad_prabhav_from + umra;
                strArrays[3] = jadPrabhavFrom.ToString();
                strArrays[4] = "] ";
                jadPrabhavFrom = jad_prabhav_from + (long)35;
                strArrays[5] = jadPrabhavFrom.ToString();
                strArrays[6] = "&";
                jadPrabhavFrom = jad_prabhav_from + (long)35 + umra;
                strArrays[7] = jadPrabhavFrom.ToString();
                strArrays[8] = "] ";
                jadPrabhavFrom = jad_prabhav_from + (long)70;
                strArrays[9] = jadPrabhavFrom.ToString();
                strArrays[10] = "&";
                jadPrabhavFrom = jad_prabhav_from + (long)70 + umra;
                strArrays[11] = jadPrabhavFrom.ToString();
                strArrays[12] = " ";
                str1 = string.Concat(strArrays);
            }
            return str1;
        }

        public string GetYearly(string lang, int year, bool unicode)
        {
            string str = "";
            if (lang == "hindi")
            {
                str = (unicode ? string.Concat(str, year.ToString(), "वें वर्ष का फल : ") : string.Concat(str, year.ToString(), "osa o\"kZ dk Qy %"));
            }
            else if (lang == "tamil")
            {
                str = string.Concat(str, year.ToString(), "tajpw;fhd tUlhe;jpu gyd;fs");
            }
            else if (lang == "bangla")
            {
                str = string.Concat(str, year.ToString(), "hRl hu­pl SeÉ h¡wp¢lL i¢hoÉà¡Z£:");
            }
            else if (lang == "telugu")
            {
                str = string.Concat(str, year.ToString(), "dŸ+eÔáàs\u0090\\ ¿±\\+ý¤ MT uó„$cÍ«y\u0090Dì");
            }
            else if (lang == "kannada")
            {
                str = string.Concat(str, year.ToString(), "£ÉÃ ªÀAiÀÄ¹ìUÉ ªÁ¶ðPÀ ¨sÀ«µÀå:");
            }
            else if (lang == "marathi")
            {
                str = string.Concat(str, year.ToString(), " o”kkZ lkBh  okf”kZd Hkfo”;QG% ");
            }
            else if (!(lang == "punjabi"))
            {
                str = (!(lang == "gujarati") ? string.Concat(str, "Yearly prediction for the age of ", year.ToString(), " year : ") : string.Concat(str, year.ToString(), " ºÐÀÐü¥ÐÕ Dð®Ð³ú ®ÐÐcêú ºÐÐÒÀÐüKú ¬ÐÒºÐÀ¯ÐºÐÐnÐÕ:"));
            }
            else
            {
                str = string.Concat(str, year.ToString(), " vyN swl dI aumr leI swl Br dI Biv~KvwxI :");
            }
            str = string.Concat(str, "\r\n");
            return str;
        }

        public string kmIsBad(string lang, string time_period)
        {
            string str = "";
            if (lang.Equals("hindi"))
            {
                str = string.Concat(str, " vkidh vk;q ds ", time_period, " o\"kksZa esa vkids gkykr vPNs gksaxs vkSj vkidks ‘kqHk Qy izkIr gksaxsA ");
            }
            else if (lang == "tamil")
            {
                str = string.Concat(str, " cq;fSila ", time_period, "-tJ taJfspy;> ePq;fs; ew;gad;fisg; ngw;W> kfpo;r;rpfukhd tho;f;ifia tho;tPHfs;. ");
            }
            else if (lang == "bangla")
            {
                str = string.Concat(str, " Bf¢e i¡m gm¡gm ®f®a Hhw p¤M£ S£h®el hvpl N¤¢m qm", time_period, " Bfe¡l hu®pz  ");
            }
            else if (lang == "telugu")
            {
                str = string.Concat(str, " MTsÁT ", time_period, "dŸ+eÔáàs\u0090\\ ejáTdŸTàýË eT+º|˜Ÿ*Ô\u0090\\qT bõ+<ŠTÔ\u0090sÁT eT]jáTT dŸ+ÔÃwŸŸ+>± J$kÍïsÁT.");
            }
            else if (lang == "kannada")
            {
                str = string.Concat(str, " ¤ªÀÄä ", time_period, " ªÀAiÀÄ¹ì£À°è ¤ÃªÀÅ M¼Éî ¥sÀ°vÁA±ÀUÀ¼À£ÀÄß ¥ÀqÉAiÀÄÄwÛÃj ªÀÄvÀÄÛ fÃªÀ£À ¸ÀAvÉÆÃµÀªÀÄAiÀÄªÁVgÀÄvÀÛzÉ. ");
            }
            else if (lang == "marathi")
            {
                str = string.Concat(str, " rqEgkyk pkaxys ifj.kke o lq[kh thou o;kP;k  ", time_period, " O;k o”khZ izkIr gksbZy%");
            }
            else if (!(lang == "punjabi"))
            {
                str = (!(lang == "gujarati") ? string.Concat(str, "You will get good results and live a happy life in the years ", time_period, " of your age.") : string.Concat(str, " oÐ®ÐÐ³úÕ Dð®Ð³ú¥ÐÐ  ", time_period, " ºÐÀÐÐêü®ÐÐï oÐ®Ðê ÁÐÐ³úÐ §ÐÑ³únÐÐ®ÐÐê ®Ðê¹ºÐ»ÐÐê A¥Ðê OÐÚ»ÐÕ¥Ð×ï XºÐ¥Ð XºÐ»ÐÐê."));
            }
            else
            {
                str = string.Concat(str, " quhwfI aumr dy  ", time_period, " swlW iv~c quhwnMU vidAw nqIjy imlxgy qy qusI KuiSAW BrI izMdgI ijaugy[");
            }
            str = string.Concat(str, "\r\n");
            return str;
        }

        public string kmIsGood(string lang, string time_period)
        {
            string str = "";
            if (lang.Equals("hindi"))
            {
                str = string.Concat(str, "vkidh vk;q ds ", time_period, " o\"kksZa esa vkids gkykr cqjs gks ldrs gSa vkSj vkidks v’kqHk Qy izkIr gks ldrs gSaA ");
            }
            else if (lang == "tamil")
            {
                str = string.Concat(str, "cq;fSila ", time_period, "-tJ taJfspy;> cq;fSf;Ff; frg;ghd tpisTfs; epfOk; kw;Wk; fLikahd fhykhf ,Uf;Fk;.");
            }
            else if (lang == "bangla")
            {
                str = string.Concat(str, "Bf¢e Ap®¸a¡oLSeL gm¡gm ®f®a f¡®le S£h®el HC hvpl N¤¢m qm ", time_period, " Bfe¡l hu®pz ");
            }
            else if (lang == "telugu")
            {
                str = string.Concat(str, "MTsÁT  ", time_period, "dŸ+eÔáàs\u0090\\ ejáTdŸTàý¤ <ŠTsÁ<Š\u008fwŸ¼¿£sÁ |˜Ÿ\\*Ô\u0090\\qT eT]jáTT ¿ì¢wŸ¼ |Ÿ]d¾ÝÔáT\\qT m<ŠTs=Ø+{²sÁT.");
            }
            else if (lang == "kannada")
            {
                str = string.Concat(str, "¤ªÀÄä ", time_period, " ªÀAiÀÄ¹ì£À°è ¤ÃªÀÅ C»vÀPÀgÀ ¥sÀ°vÁA±ÀUÀ¼À£ÀÄß ¥ÀqÉAiÀÄ§ºÀÄzÀÄ ªÀÄvÀÄÛ PÀµÀÖPÀgÀªÁzÀ ¥Àj¹ÜwUÀ¼À£ÀÄß JzÀÄj¸À§ºÀÄzÀÄ.");
            }
            else if (lang == "marathi")
            {
                str = string.Concat(str, "rqEgkyk o;kP;k ", time_period, " ;k o”kkZr okbZV ifj.kke o dfBu osGspk lkeuk djkok ykxsy%");
            }
            else if (!(lang == "punjabi"))
            {
                str = (!(lang == "gujarati") ? string.Concat(str, "You may get unpleasant results and face tough times in the years ", time_period, " of your age.") : string.Concat(str, " oÐ®ÐÐ³úÕ Dð®Ð³ú¥ÐÐ ", time_period, " ºÐÀÐÐêü®ÐÐï oÐ®Ðê AÒ§Ðõ¯Ð §ÐÑ³únÐÐ®ÐÐê ®Ðê¹ºÐÕ »ÐKú»ÐÐê A¥Ðê OÐ³úÐ«Ð ÁÐ®Ð¯Ð¥ÐÐê ÁÐÐ®Ð¥ÐÐê Kú³úºÐÐê §ÐhúÕ »ÐKêú."));
            }
            else
            {
                str = string.Concat(str, "quhwfI aumr dy ", time_period, " swlW iv~c quhwnMU mwVy nqIjy imlxgy qy AOKy vyly dw swhmxw krxw pvygw[");
            }
            str = string.Concat(str, "\r\n");
            return str;
        }

        public string major(string lang, string year, bool unicode)
        {
            string str = "";
            if (lang.ToLower() == "hindi")
            {
                str = (unicode ? string.Concat(str, "।।। ", year.ToString(), "वें वर्ष में निम्नलिखित फल का प्रभाव अत्यधिक होगा: ।।।") : string.Concat(str, "AAA ", year.ToString(), "osa o\"kZ esa fuEufyf[kr Qy dk izHkko vR;f/kd gksxk % AAA"));
            }
            else if (lang.ToLower() == "tamil")
            {
                str = string.Concat(str, "gpd;tUk; tpisTfs;> cq;fSila ", year.ToString(), "–tJ tajpy; nghpa jhf;fj;ij Vw;gLj;Jk;.");
            }
            else if (lang.ToLower() == "bangla")
            {
                str = string.Concat(str, year.ToString(), " hRl hu­p flhaÑ£ gm¡gm…¢m Bfe¡l S£h­e A­eL ­h¢n fËi¡h ¢hÙ¹¡l Ll­hz ");
            }
            else if (lang.ToLower() == "telugu")
            {
                str = string.Concat(str, "‡ ~>·Te |˜Ÿ*Ô\u0090T, MTÅ£”", year.ToString(), "dŸ+eÔáàs\u0090 ejáTdŸTàýË >·DújáTyîT®q ç|Ÿuó²y\u0090“• #áÖ|ŸÚÔ\u0090sTT.");
            }
            else if (lang.ToLower() == "kannada")
            {
                str = string.Concat(str, "¤ªÀÄä ", year.ToString(), " £ÉÃ ªÀAiÀÄ¹ì£À°è ¤ªÀÄä fÃªÀ£ÀzÀ°è F PÉ¼ÀV£ÀªÀÅ ºÉaÑ£À ¥Àæ¨sÁªÀ ©ÃgÀÄvÀÛªÉ.");
            }
            else if (lang.ToLower() == "marathi")
            {
                str = string.Concat(str, "[kkyhy ifj.kke o;kP;k ", year, " O;k o”khZ rqeP;k thoukr vf/kd izHkko’kkyh vlrhy%");
            }
            else if (!(lang.ToLower() == "punjabi"))
            {
                str = (!(lang.ToLower() == "gujarati") ? string.Concat(str, "Following results will have major impact in your life at the age of ", year.ToString(), " year.") : string.Concat(str, " ¥ÐÕSÐê¥ÐÐ §ÐÑ³únÐÐ®ÐÐê ", year, " ºÐÀÐü¥ÐÕ Dð®Ð³êú oÐ®ÐÐ³úÐ XºÐ¥Ð®ÐÐï ®ÐÐêcúÕ AÁÐ³ú Kú³ú»Ðê."));
            }
            else
            {
                str = string.Concat(str, year, " vyN swl dI aumr iv~c hyT ilKy nqIjy quhwfI izMdgI iv~c izAwdw pRBwv pwauxgy[");
            }
            str = string.Concat(str, "\r\n");
            return str;
        }

        public string major_month(string lang, string year, short month, bool unicode)
        {
            string str;
            string[] codeLang;
            string str1 = "";
            PredictionBLL predictionBLL = new PredictionBLL();
            if (lang.ToLower() == "hindi")
            {
                if (unicode)
                {
                    str = str1;
                    codeLang = new string[] { str, "।।। ", year.ToString(), " वर्ष के जन्ममाह से ", predictionBLL.GetCodeLang(month.ToString(), lang, false, unicode), " महीने का फलादेश: - ।।।" };
                    str1 = string.Concat(codeLang);
                }
                else
                {
                    str = str1;
                    codeLang = new string[] { str, "AAA ", year.ToString(), "o\"kZ ds tUeekg ls ", predictionBLL.GetCodeLang(month.ToString(), lang, unicode), " eghus dk Qykns’k % & AAA" };
                    str1 = string.Concat(codeLang);
                }
            }
            if (lang.ToLower() == "marathi")
            {
                str = str1;
                codeLang = new string[] { str, "AAA ", year.ToString(), " O;k o\"kkZP;k tUeekg iklwu ", predictionBLL.GetCodeLang(month.ToString(), lang, unicode), " efgU;kps QG AAA" };
                str1 = string.Concat(codeLang);
            }
            if (lang.ToLower() == "punjabi")
            {
                str = str1;
                codeLang = new string[] { str, year.ToString(), " swl ", predictionBLL.GetCodeLang(month.ToString(), lang, unicode), " mihnw :- " };
                str1 = string.Concat(codeLang);
            }
            if (lang.ToLower() == "gujarati")
            {
                str = str1;
                codeLang = new string[] { str, year.ToString(), " ºÐÀÐêü ", predictionBLL.GetCodeLang(month.ToString(), lang, unicode), " ®ÐÐÅ " };
                str1 = string.Concat(codeLang);
            }
            if (lang.ToLower() == "english")
            {
                str = str1;
                codeLang = new string[] { str, "||| Predictions for the ", predictionBLL.GetCodeLang(month.ToString(), lang, unicode), " month of your age ", year.ToString(), "  |||" };
                str1 = string.Concat(codeLang);
            }
            if (lang.ToLower() == "bangla")
            {
                str = str1;
                codeLang = new string[] { str, year.ToString(), "hR­ll S¸j j¡­pl ", predictionBLL.GetCodeLang(month.ToString(), lang, unicode), "  j¡­pl gm¡­cn :-" };
                str1 = string.Concat(codeLang);
            }
            str1 = string.Concat(str1, "\r\n");
            return str1;
        }

        public string result(string lang, string time_period)
        {
            string str = "";
            if (lang.Equals("hindi"))
            {
                str = string.Concat(str, "vkidh vk;q ds ", time_period, "o\"kksZa esa uhps fn, x, Qy ?kfVr gksaxs % ");
            }
            else if (lang == "tamil")
            {
                str = string.Concat(str, "cq;fSila  ", time_period, "–tJ taJfspy; gpd;tUk; tpisTfs; nghpa jhf;fj;ij Vw;gLj;Jk;.");
            }
            else if (lang == "bangla")
            {
                str = string.Concat(str, " ¢ejÀ¢m¢Ma gm¡gm…¢m Bfe¡l S£h®el ", time_period, " hRl hup…¢m®a …l¦al fËi¡h ®gm®a f¡®l ");
            }
            else if (lang == "telugu")
            {
                str = string.Concat(str, "MTsÁT", time_period, "dŸ+eÔáàs\u0090\\ ejáTdŸTàýË ‡ |˜Ÿ*Ô\u0090\\T MT™|Õ >·DújáTyîT®q ç|Ÿuó„y\u0090“• #áÖ|ŸÚÔ\u0090sTT. ");
            }
            else if (lang == "kannada")
            {
                str = string.Concat(str, "¤ªÀÄä 1jAzÀ", time_period, " ªÀAiÀÄ¹ì£À°è ¤ªÀÄä fÃªÀ£ÀzÀ°è F PÉ¼ÀV£ÀªÀÅ ºÉaÑ£À ¥Àæ¨sÁªÀ ©ÃgÀ§ºÀÄzÀÄ: ");
            }
            else if (lang == "marathi")
            {
                str = string.Concat(str, "[kkyhy ifj.kke rqeP;k thoukr o;kP;k ", time_period, "O;k o”kkZr vf/kd izHkko’kkyh vlrhy%");
            }
            else if (!(lang == "punjabi"))
            {
                str = (!(lang == "gujarati") ? string.Concat(str, "Following results may have major impact in your life for years ", time_period, " of your age : ") : string.Concat(str, " ¥ÐÕSÐê¥ÐÐ §ÐÑ³únÐÐ®ÐÐê, oÐ®ÐÐ³úÕ Dð®Ð³ú¥ÐÐ ", time_period, " ºÐÀÐÐêü ®ÐÐcêú oÐ®ÐÐ³úÐ XºÐ¥Ð®ÐÐï ®ÐÐêcúÕ AÁÐ³ú §ÐÐhúÕ »ÐKêú:"));
            }
            else
            {
                str = string.Concat(str, "quhwfI aumr dy  ", time_period, " swlW iv~c hyT ilKy nqIjy bhuq izAwdw pRBwv pwauxgy :");
            }
            return str;
        }
    }
}