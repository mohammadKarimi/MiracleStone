$.validator.addMethod("IsNatinalCode",
                  function (value, element) {
                      if (value.length == 0)
                          return true;
                      else if (value.length == 10) {
                          if (value == '1111111111' || value == '0000000000' || value == '2222222222' || value == '3333333333' || value == '4444444444' || value == '5555555555' || value == '7777777777' || value == '8888888888' || value == '9999999999')
                              return false;
                          else if (value.charAt(0) == '0' && value.charAt(1) == '0' && value.charAt(2) == '0' && value.charAt(3) == '0' && value.charAt(4) == '0' && value.charAt(5) == '0' && value.charAt(6) == '0')
                              return false;
                          else {
                              c = parseInt(value.charAt(9));
                              n = parseInt(value.charAt(0)) * 10 + parseInt(value.charAt(1)) * 9 + parseInt(value.charAt(2)) * 8 + parseInt(value.charAt(3)) * 7 + parseInt(value.charAt(4)) * 6 + parseInt(value.charAt(5)) * 5 + parseInt(value.charAt(6)) * 4 + parseInt(value.charAt(7)) * 3 + parseInt(value.charAt(8)) * 2;
                              r = n - parseInt(n / 11) * 11;
                              if ((r == 0 && r == c) || (r == 1 && c == 1) || (r > 1 && c == 11 - r))
                                  return true;
                              else
                                  return false;
                          }
                      }
                      else
                          return false;
                  },
                  "<span class='requiredFieldStyle'>لطفا کد ملي را تصحيح كنيد</span>"
             );
