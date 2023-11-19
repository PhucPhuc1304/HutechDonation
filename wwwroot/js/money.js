const defaultNumbers = ' hai ba bốn năm sáu bảy tám chín';
const chuHangDonVi = ('1 một' + defaultNumbers).split(' ');
const chuHangChuc = ('lẻ mười' + defaultNumbers).split(' ');
const chuHangTram = ('không một' + defaultNumbers).split(' ');

function convert_block_three(number) {
    if (number === '000') return '';
    var _a = number + '';

    switch (_a.length) {
        case 1:
            return chuHangDonVi[_a];
        case 2:
            return convert_block_two(_a);
        case 3:
            var chuc_dv = '';
            if (_a.slice(1, 3) !== '00') {
                chuc_dv = convert_block_two(_a.slice(1, 3));
            }
            var tram = chuHangTram[_a[0]] + ' trăm';
            return tram + ' ' + chuc_dv;
    }
}

function convert_block_two(number) {
    var dv = chuHangDonVi[number[1]];
    var chuc = chuHangChuc[number[0]];
    var append = '';

    if (number[0] > 0 && number[1] == 5) {
        dv = 'lăm';
    }

    if (number[0] > 1) {
        append = ' mươi';

        if (number[1] == 1) {
            dv = ' mốt';
        }
    }

    return chuc + '' + append + ' ' + dv;
}

const dvBlock = '1 nghìn triệu tỷ'.split(' ');

function to_vietnamese(number) {
    var str = parseInt(number) + '';
    var i = 0;
    var arr = [];
    var index = str.length;
    var result = [];
    var rsString = '';

    if (index == 0 || str == 'NaN') {
        return '';
    }

    // Chia chuỗi số thành một mảng từng khối có 3 chữ số
    while (index >= 0) {
        arr.push(str.substring(index, Math.max(index - 3, 0)));
        index -= 3;
    }

    // Lặp từng khối trong mảng trên và convert từng khối đấy ra chữ Việt Nam
    for (i = arr.length - 1; i >= 0; i--) {
        if (arr[i] != '' && arr[i] != '000') {
            result.push(convert_block_three(arr[i]));

            // Thêm đuôi của mỗi khối
            if (dvBlock[i]) {
                result.push(dvBlock[i]);
            }
        }
    }

    // Join mảng kết quả lại thành chuỗi string
    rsString = result.join(' ');
    rsString = rsString.charAt(0).toUpperCase() + rsString.slice(1);

    // Trả về kết quả kèm xóa những ký tự thừa
    return rsString.replace(/[0-9]/g, '').replace(/ /g, ' ').replace(/ $/, '');
}

function addCommas(input) {
    // Lấy giá trị nhập liệu từ trường input
    let inputValue = input.value;


    // Loại bỏ tất cả dấu phẩy có sẵn (nếu có)
    inputValue = inputValue.replace(/,/g, '');

    // Chuyển đổi giá trị thành số nguyên
    let intValue = parseInt(inputValue, 10);

    // Kiểm tra xem giá trị nhập liệu có phải là một số hay không
    if (!isNaN(intValue)) {
        // Format giá trị đã chuyển đổi thành chuỗi có dấu phẩy
        let formattedValue = intValue.toLocaleString('en-US');

        // Gán giá trị đã được định dạng trở lại trường input
        input.value = formattedValue;
        let money_ = input.value;
        money_Split = money_.replace(/,/g, '');
        console.log(money_)

        let vietnameseText = to_vietnamese(money_Split);
        let vietnameseText_ = vietnameseText + ' đồng.';
        // Hiển thị kết quả trên trường nhập liệu 'amount_text'
        document.getElementById('amount_text').value = vietnameseText_;
    } else {
        // Nếu giá trị không phải là một số hợp lệ, không thêm dấu phẩy
        input.value = inputValue;
    }
}
