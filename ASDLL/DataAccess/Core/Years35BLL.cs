using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using AstroShared.Models;
namespace ASDLL.DataAccess.Core
{
    public class Years35BLL
    {
        public Years35BLL()
        {
        }

        public List<Years35VO> Get35Years(string planet)
        {
            string planetname = planet;
            PlanetBLL planetBLL = new PlanetBLL();
            short num = 1;
            string str = "";
            List<PlanetVO> allPlanets = planetBLL.GetAllPlanets();
            PlanetVO planetVO = allPlanets.Find((PlanetVO p) => p.PlanetnameEnglish == planetname);
            planetname = planetVO.Planetname;
            List<Years35VO> years35VOs = new List<Years35VO>();
            DataTable years35 = (new Years35DAO()).GetYears35(planetname);
            double i = 1;
            double num1 = 1;
            double num2 = 0;
            double num3 = 1;
            bool flag = false;
            bool flag1 = false;
            foreach (DataRow row in years35.Rows)
            {
                num3 = 1;
                flag = false;
                flag1 = false;
                for (i = 1; i <= (double)Convert.ToInt64(row["years"].ToString()); i += 1)
                {
                    Years35VO years35VO = new Years35VO();
                    if ((row["planet"].ToString() == "Surya" || row["planet"].ToString() == "Budh" ? false : !(row["planet"].ToString() == "Chandra")))
                    {
                        num2 = (double)(Convert.ToInt64(row["years"].ToString()) / (long)3);
                        years35VO.Years = Convert.ToInt64(num1);
                        years35VO.Planet = row["planet"].ToString();
                        if (num3 <= num2)
                        {
                            years35VO.Period = row["mid1"].ToString();
                        }
                        if ((num3 <= num2 ? false : num3 <= num2 + num2))
                        {
                            years35VO.Period = row["mid2"].ToString();
                        }
                        if ((num3 <= num2 + num2 ? false : num3 <= num2 + num2 + num2))
                        {
                            years35VO.Period = row["mid3"].ToString();
                        }
                        num3 += 1;
                    }
                    else
                    {
                        if (row["planet"].ToString() == "Surya")
                        {
                            if (flag)
                            {
                                years35VO.Years = Convert.ToInt64(num1);
                                years35VO.Planet = "Surya";
                                years35VO.Period = "Chandra/Mangal";
                                flag = true;
                            }
                            else
                            {
                                years35VO.Years = Convert.ToInt64(num1);
                                years35VO.Planet = "Surya";
                                years35VO.Period = "Surya/Chandra";
                                flag = true;
                            }
                        }
                        if (row["planet"].ToString() == "Chandra")
                        {
                            years35VO.Years = Convert.ToInt64(num1);
                            years35VO.Planet = "Chandra";
                            years35VO.Period = "Guru/Surya/Chandra";
                        }
                        if (row["planet"].ToString() == "Budh")
                        {
                            if (flag1)
                            {
                                years35VO.Years = Convert.ToInt64(num1);
                                years35VO.Planet = "Budh";
                                years35VO.Period = "Mangal/Budh";
                                flag1 = true;
                            }
                            else
                            {
                                years35VO.Years = Convert.ToInt64(num1);
                                years35VO.Planet = "Budh";
                                years35VO.Period = "Chandra/Mangal";
                                flag1 = true;
                            }
                        }
                    }
                    if (!(str != years35VO.Planet))
                    {
                        years35VO.Sno = (long)(num - 1);
                    }
                    else
                    {
                        years35VO.Sno = (long)num;
                        num = (short)(num + 1);
                    }
                    str = years35VO.Planet;
                    years35VOs.Add(years35VO);
                    num1 += 1;
                }
            }
            return years35VOs;
        }

        public List<Years35VO> Get35YearsAll()
        {
            List<Years35VO> years35VOs = new List<Years35VO>();
            foreach (DataRow row in (new Years35DAO()).GetYears35All().Rows)
            {
                Years35VO years35VO = new Years35VO()
                {
                    Planet = row["planet"].ToString(),
                    Years = Convert.ToInt64(row["years"])
                };
                years35VOs.Add(years35VO);
            }
            return years35VOs;
        }

        public List<JanamAamVO> GetAam()
        {
            List<JanamAamVO> janamAamVOs = new List<JanamAamVO>();
            foreach (DataRow row in (new Years35DAO()).JanamAam().Rows)
            {
                JanamAamVO janamAamVO = new JanamAamVO()
                {
                    Years = Convert.ToInt64(row["years"].ToString()),
                    Planet = row["planet"].ToString(),
                    Antar = row["antar"].ToString()
                };
                janamAamVOs.Add(janamAamVO);
            }
            return janamAamVOs;
        }

        public List<AntarVO> GetAntar(string planet)
        {
            List<AntarVO> antarVOs = new List<AntarVO>();
            foreach (DataRow row in (new Years35DAO()).Antar(planet).Rows)
            {
                AntarVO antarVO = new AntarVO()
                {
                    Planet = row["planet"].ToString(),
                    Mid1 = row["mid1"].ToString(),
                    Mid2 = row["mid2"].ToString(),
                    Mid3 = row["mid3"].ToString()
                };
                antarVOs.Add(antarVO);
            }
            return antarVOs;
        }

        public long GetUmra(string planet)
        {
            long num = (long)0;
            foreach (DataRow row in (new Years35DAO()).GetYears35_Umra(planet).Rows)
            {
                num = Convert.ToInt64(row["years"]);
            }
            return num;
        }
    }
}