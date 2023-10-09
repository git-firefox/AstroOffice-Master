using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;

namespace Kunda
{
    internal static class MDLKundali
    {
        public static double d2r;

        public static double pi;

        public static double r2d;

        public static double ayan;

        public static double t;

        public static double delT;

        public static int[] days;

        public static float[] cusp;

        public static float[] bho;

        public static int[] bhav;

        public static int[] Swami;

        public static string[] grah;

        public static string[] bhava;

        public static string[] ras;

        public static string[] Nak;

        public static MDLKundali.GharType[] QHouse;

        public static MDLKundali.PlanetType[] QPlanet;

        public static MDLKundali.PlanetType[] TPlanet;

        public static byte TLagnA;

        public static MDLKundali.GharType[] THouse;

        static MDLKundali()
        {
            MDLKundali.days = new int[13];
            MDLKundali.cusp = new float[13];
            MDLKundali.bho = new float[13];
            MDLKundali.bhav = new int[13];
            MDLKundali.Swami = new int[13];
            MDLKundali.grah = new string[13];
            MDLKundali.bhava = new string[13];
            MDLKundali.ras = new string[13];
            MDLKundali.Nak = new string[28];
            MDLKundali.QHouse = new MDLKundali.GharType[13];
            MDLKundali.QPlanet = new MDLKundali.PlanetType[13];
            MDLKundali.TPlanet = new MDLKundali.PlanetType[13];
            MDLKundali.THouse = new MDLKundali.GharType[13];
        }

        public struct GharType
        {
            public byte PlanetsInHouse;

            public byte Rashi;

            public event MDLKundali.GharType.ABCEventHandler ABC;

            public delegate void ABCEventHandler(byte XYZ);
        }

        public struct PlanetType
        {
            public string pName;

            public string pNameENG;

            public float Debilitate;

            public byte OwnerRashi;

            public byte MTRashi;

            public byte UchRashi;

            public float Postion;

            public float Speed;

            public byte Rashi;

            public bool isBad;

            public int Ghar;

            public byte MoonGhar;

            public byte HoraRashi;

            public byte HoraGhar;

            public byte DreskanRashi;

            public byte DreskanGhar;

            public byte SaptmansRashi;

            public byte SaptmansGhar;

            public byte NavmansRashi;

            public byte NavnansGhar;

            public byte DwadsansGhar;

            public byte DwadsansRashi;

            public byte TrisansGhar;

            public byte TrisansRashi;

            public float Bal_Uch;

            public float Bal_YugmaYugm;

            public float Bal_Kendradi;

            public float Bal_Dreshkan;

            public float Bal_SaptVarg;

            public float Bal_Dig;

            public float Bal_Kal;

            public float Bal_Cheshta;

            public float Bal_Naisargik;

            public float Bal_Drik;

            public float Bal_Isht;

            public float Bal_Kasht;

            public event MDLKundali.PlanetType.ABCEventHandler ABC;

            public delegate void ABCEventHandler(byte XYZ);
        }

        public struct PosInKundli
        {
            public byte x;

            public byte y;

            public event MDLKundali.PosInKundli.ABCEventHandler ABC;

            public delegate void ABCEventHandler(byte XYZ);
        }
    }
}