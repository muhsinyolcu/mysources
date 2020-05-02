using ClosedXML.Excel;
using mySource.WebApp.MVC.Services.Product;
using System.Data;
using System.IO;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mySource.WebApp.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            return View(_productService.GetProducts());
        }

        public ActionResult ExportToExcelMethod1()
        {
            var products = _productService.GetProducts();

            var gV = new GridView();
            gV.DataSource = products;
            gV.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gV.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();

            return View("Index", products);
        }

        public FileResult ExportToExcelMethod2()
        {
            var products = _productService.GetProducts();

            DataTable dt = new DataTable("Products");
            dt.Columns.AddRange(new DataColumn[3] {
            new DataColumn("Id"),
            new DataColumn("Product Name"),
            new DataColumn("Price")
            });

            foreach (var product in products)
            {
                dt.Rows.Add(product.ProductId, product.ProductName, product.ProductPrice);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Products.xlsx");
                }
            }
        }
    }
}