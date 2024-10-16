using AppData.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Validator
{
    public class XeThueValidator : AbstractValidator<XeThue>
    {
        public XeThueValidator()
        {
            RuleFor(x => x.TenXe)
                .NotEmpty().WithMessage("Tên xe không được để trống.")
                .MaximumLength(100).WithMessage("Tên xe không được dài hơn 100 ký tự.");

            RuleFor(x => x.HangXe)
                .NotEmpty().WithMessage("Hãng xe không được để trống.")
                .MaximumLength(50).WithMessage("Hãng xe không được dài hơn 50 ký tự.");

            RuleFor(x => x.NgayThue)
                .LessThan(x => x.NgayTra).WithMessage("Ngày thuê phải trước ngày trả.");

            RuleFor(x => x.GiaThueMoiNgay)
                .GreaterThan(0).WithMessage("Giá thuê mỗi ngày phải lớn hơn 0.");

            RuleFor(x => x.TrangThai)
                .Must(BeAValidStatus).WithMessage("Trạng thái không hợp lệ. Phải là một trong các giá trị: Có sẵn, Đang thuê, Bảo trì.");
        }

        private bool BeAValidStatus(string status)
        {
            return status == "Có sẵn" || status == "Đang thuê" || status == "Bảo trì";
        }
    }
}
