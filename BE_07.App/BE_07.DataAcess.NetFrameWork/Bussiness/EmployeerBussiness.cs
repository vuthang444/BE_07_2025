using BE_07.DataAcess.NetFrameWork.DO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_07.DataAcess.NetFrameWork.Bussiness
{
	public class EmployeerBussiness
	{
		List<Employeer> list = new List<Employeer>();
		public ReturnData NhapDanhSach()
		{   var ReturnData = new ReturnData();
			try 
			{
				var employyeerID_InPut = Console.ReadLine();
				var isvalid = Common.ValidateData.CheckNull_Data(employyeerID_InPut);
				if (!isvalid)
				{	
					ReturnData.ReturnCode=(int)Ma_Loi.IdTrong;
					ReturnData.ReturnMsg= "ID không đươc để trống";
					return ReturnData;
				}
				var emp = new Employeer();
				emp.EmployeerID = employyeerID_InPut;
				list.Add(emp);
				
			}
			catch(Exception ex) 
			{
				ReturnData.ReturnCode = (int)Ma_Loi.EXCEPTION;
				ReturnData.ReturnMsg = ex.Message;
				ReturnData.ReturnMsg =ex.StackTrace;
				return ReturnData;
			}

			ReturnData.ReturnCode = (int)Ma_Loi.ThanhCong;
			ReturnData.ReturnMsg = "Thêm thành công";
			return ReturnData;
		}
		public ReturnData NhapTuExcelFile(string filePath) 
		{
			var ReturnData = new ReturnData();
			var errorItem =new StringBuilder();
			try
			{
				FileInfo existingFile = new FileInfo(filePath);
				using (ExcelPackage package = new ExcelPackage(existingFile))
				{
					//get the first worksheet in the workbook
					ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
					int colCount = worksheet.Dimension.End.Column;  //get Column Count
					int rowCount = worksheet.Dimension.End.Row;     //get row count
					for (int row = 2; row <= rowCount; row++)
					{
						
						var maNhanvien = worksheet.Cells[row, 1].Value.ToString().Trim();
						var hoTen = worksheet.Cells[row, 2].Value.ToString().Trim();
						var ngaySinh = worksheet.Cells[row, 3].Value.ToString().Trim();
						var ngayVaoLam = worksheet.Cells[row, 4].Value.ToString().Trim();

						var isValidMaNhanVien = Common.ValidateData.CheckNull_Data(maNhanvien);
						if (!isValidMaNhanVien) 
						{
							errorItem.Append("Ma loi o hang : + row cot : 1");
							continue;
						}
						var isValidHoTen = Common.ValidateData.CheckNull_Data(hoTen);
						if (!isValidMaNhanVien)
						{
							errorItem.Append("Ma loi o hang : + row cot : 2");
							continue;
						}
						var isValidNgaySinh = Common.ValidateData.CheckNull_Data(ngaySinh);
						if (!isValidMaNhanVien)
						{
							errorItem.Append("Ma loi o hang : + row cot : 3");
							continue;
						}
						var isValidNgayVaoLam = Common.ValidateData.CheckNull_Data(ngayVaoLam);
						if (!isValidMaNhanVien)
						{
							errorItem.Append("Ma loi o hang : + row cot : 4");
							continue;
						}

					}
				}
				if (errorItem != null)
				{
					ReturnData.ReturnCode = (int)Ma_Loi.ThatBai;
					ReturnData.ReturnMsg =errorItem.ToString();
					
					return ReturnData;
				}

			}
			catch (Exception ex)
			{
				ReturnData.ReturnCode = (int)Ma_Loi.EXCEPTION;
				ReturnData.ReturnMsg = ex.Message;
				ReturnData.ReturnMsg = ex.StackTrace;
				return ReturnData;
			}
		}


	}
}
