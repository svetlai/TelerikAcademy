﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _8._6.Web_Counter_DB
{
    public partial class WebCounter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new WebCounterDbContext();

            db.Visitors.Add(new Visitor());
            db.SaveChanges();

            Response.Clear();

            Bitmap generatedImage = new Bitmap(200, 200);
            using (generatedImage)
            {
                Graphics gr = Graphics.FromImage(generatedImage);
                using (gr)
                {
                    // Create string to draw.
                    string num = db.Visitors.Count().ToString();

                    gr.FillRectangle(Brushes.MediumSeaGreen, 0, 0, 200, 200);

                    // Create font and brush.
                    Font drawFont = new Font("Arial", 24);
                    SolidBrush drawBrush = new SolidBrush(Color.Blue);

                    // Create point for upper-left corner of drawing.
                    PointF drawPoint = new PointF(80.0F, 80.0F);

                    gr.DrawString(num, drawFont, drawBrush, drawPoint);

                    //gr.FillPie(Brushes.Yellow, 25, 25, 150, 150, 0, 45);
                    //gr.FillPie(Brushes.Green, 25, 25, 150, 150, 45, 315);

                    // Set response header and write the image into response stream
                    Response.ContentType = "image/gif";

                    //Response.AppendHeader("Content-Disposition",
                    //    "attachment; filename=\"Financial-Report-April-2013.JPEG\"");

                    generatedImage.Save(Response.OutputStream, ImageFormat.Jpeg);
                }
            }
        }
    }
}