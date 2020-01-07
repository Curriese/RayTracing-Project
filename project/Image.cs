﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;
using System.Drawing.Imaging;

namespace project.RayTracing
{
    public class Image
    {
        Bitmap b;
        RenderVisualizer RV;

        /// <summary>
        /// Creates an image based off a bitmap 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="outputFilePath"></param>
        public Image(Camera c, Mesh scene, string outputFilePath, String accelStruct)
        {
            this.b = generateImage(c, scene, accelStruct);
            Graphics g = Graphics.FromImage(b);
            g.Dispose();
            b.Save(outputFilePath, ImageFormat.Png);
            b.Dispose();
        }

        /// <summary>
        /// Creates an image based off a bitmap 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="outputFilePath"></param>
        public Image(Camera c, Mesh scene, string outputFilePath, RenderVisualizer RV, String accelStruct)
        {
            this.RV = RV;
            this.b = generateImage(c, scene, accelStruct);
            Graphics g = Graphics.FromImage(b);
            g.Dispose();
            b.Save(outputFilePath, ImageFormat.Png);
            b.Dispose();
        }

        /// <summary>
        /// generates an Image by shooting one Ray per pixel into our scene
        /// </summary>
        /// <param name="c"></param>
        /// <param name="scene"></param>
        /// <returns></returns>
        public Bitmap generateImage(Camera c, Mesh scene, String accelStruct)
        {
            int ResX = c.getResX();
            int ResY = c.getResY();
            Bitmap b = new Bitmap(ResX, ResY);
            //Start Timer here.
            GridAccelerator gridAccelerator = null;
            if (accelStruct == "Grid")
            {
                gridAccelerator = new GridAccelerator(scene);
            }
            for (int i = 0; i < ResX; i++)
            {
                //Check how far the rendering is
                for (int j = 0; j < ResY; j++)
                {
                    Color newColor;
                    Ray r = c.getRay(new Vector2(i,j));
                    

                    Triangle intersect = null;
                    if(accelStruct == "Grid")
                    {
                        intersect = gridAccelerator.intersect(r);
                    }
                    else  
                    {
                        //Brute Force
                        intersect = scene.intersect(r);
                    }
                    if (intersect != null)
                    {
                        Vector3 normal = intersect.normal(r);
                        float red = ((normal.X + 1) / 2) * 255;
                        float green = ((normal.Y + 1) / 2) * 255;
                        float blue = ((normal.Z + 1) / 2) * 255;
                        newColor = Color.FromArgb((int)red, (int)green, (int)blue);
                    }
                    else
                    {
                        newColor = Color.FromArgb(0, 0, 0);
                    }
                    
                    b.SetPixel(i, ResY - j - 1 , newColor);
                }
                if(RV != null && i % 5 == 0)
                {
                    RV.updateBitmap(b);
                }

            }
            //End Timer here
            return b;
        }
    }
}
