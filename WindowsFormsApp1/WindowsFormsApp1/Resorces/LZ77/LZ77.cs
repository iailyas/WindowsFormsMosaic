using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Resorces.LZ77
{
    public class LZ77
    {
       
        public String Decode(string input) 
        {
            string text = input;//забираем текст, состоящий из меток
            text = text.Replace(") (", ")(");//избавляемся от лишних пробелов
            //string [] element_mets = text.Split(')');//разделяем метки на массив, удаляя из них закрывающую скобку
            string result_text = "";//создаем пустой текст, который будет выведен в результат
            while (text != "" && text != " ")//выполняем для текста из меток, пока они не закончатся
            {
                text = text.Remove(0, 1);//удаляем из очередной метки открывающую скобку
                int offset = Convert.ToInt32(text.Remove(text.IndexOf(',')));//извлекаем номер позиции для построения подстроки
                text = text.Remove(0, text.IndexOf(',') + 1);//убираем его из метки
                int len = Convert.ToInt32(text.Remove(text.IndexOf(',')));//извлекаем длину подстроки
                text = text.Remove(0, text.IndexOf(',') + 1);//убираем ее из метки
                string last_symbol = text.Remove(1);//извлекаем символ, которым оканчивается подстрока
                text = text.Remove(0, 2);//извлекаем символ и закрывающую скобку из текста, полностью стирая из него только что обработанную метку
                if (offset == 0 && len == 0)//если символ или подстрока ранее не встречался при декодировании, то 
                {
                    result_text += last_symbol;//он добавляется в результат
                }
                else
                {//если подстрока уже есть в выходной последовательности, то  
                    string temp_res_text = result_text;//создается временная копия выходного текста,
                    temp_res_text = temp_res_text.Remove(0, temp_res_text.Length - offset);//которая обрезается до первого символа, на который указывает позиция из метки
                    if (temp_res_text.Length != len)//если длина оставшегося текста из обрезаной последовательности больше чем длина подстроки (из метки)
                        temp_res_text = temp_res_text.Remove(len);//то обрезается с другого конца
                    result_text += temp_res_text + last_symbol;//и добавляется в выходную последовательность                    
                }
            }
            return result_text;//вывод текста в текстовое поле
        }
        public String Encode(String str)
        {
            int search_buffer_size = str.Length;//размер буффера поиска
            string search_buffer = "";//создание пустого буффера поиска
            string proactive_buffer = str;//создание упреждающего буффера с текстом, который будет упаковываться
            string result_text = ""; //создание переменной, в которую будет вписываться результат
                                     // заполнение упреждающего буффера количеством символов, указанным в соответствующем текстовом поле 
            while (proactive_buffer.Length != 0)//далее упаковываем, пока количество символов в упреждающем буффере не будет равно 0 (далее по алгоритму такая ситуация возникнет когда закончатся необработанные символы текста)
            {
                string temp_proactive_buffer = proactive_buffer;//создадим копию упреждающего буффера, которая в цикле (начинается с строки 32)проверки наличия совпадения строки будет обрезаться
                string coincident_text = ""; //создаем переменную, в которую запишем строку или подстроку из упреждающего буффера, совпавшую с фрагментом строки буффера поиска (в цикле ниже)                              
                for (int j = 0; j < proactive_buffer.Length - 1; j++)//в цикле проверяем, есть ли в буффере поиска строка или часть строки из упреждающего буффера
                {
                    if (search_buffer.Contains(coincident_text + temp_proactive_buffer.Remove(1)) == true)//если уже имеющаяся подстрока+ 1 символ из упреждающего буффера есть в буффере поиска (словаре), то 
                    {
                        coincident_text += temp_proactive_buffer.Remove(1);//добавляем символ в совпавшую подстроку
                        temp_proactive_buffer = temp_proactive_buffer.Remove(0, 1);//обрезаем копию буффера
                    }
                    else break;//если подстрока+символ из упреждающего буффера не содержится в буффере поиска, то цикл прерывается
                }
                if (proactive_buffer.Length == 1 && search_buffer.Contains(coincident_text + proactive_buffer) == true)//это работает аналогично циклу, но обрабатывает последний символ из упреждающего буффера
                {
                    coincident_text += proactive_buffer;//добавляем символ в совпавшую подстроку
                }
                string temp_search_buffer = search_buffer;//создаем копию буффера поиска
                string search_current_substring = "";//создаем переменную для записи подстроки из буффера поиска, в которой будем искать совпадение
                int offset = 0;//создаем переменную, отвечающую за номер позиции начала подстроки в буффере поиска (смещение)
                for (int i = 0; i < search_buffer.Length; i++)//в цикле проходим по буфферу поиска, ища строку, совпадающую с подстрокой из буффера
                {
                    if (temp_search_buffer.Length > coincident_text.Length)
                        search_current_substring = temp_search_buffer.Remove(coincident_text.Length);
                    else search_current_substring = temp_search_buffer;
                    if (coincident_text == search_current_substring && coincident_text != "")
                    {
                        offset = search_buffer.Length - i;//если находим, то присваиваем смещению номер позиции символа в строке
                        break;
                    }
                    else temp_search_buffer = temp_search_buffer.Remove(0, 1);
                }
                string last_symbol = "";//создаем переменную и определяем в нее символ, который пойдет в выходную метку.
                if (proactive_buffer.Length > coincident_text.Length + 1)//отделяем этот символ от остальных в упреждающем буффере (при их наличии)
                    last_symbol = proactive_buffer.Remove(coincident_text.Length + 1);
                else last_symbol = proactive_buffer;
                if (last_symbol.Length > 1)
                    last_symbol = last_symbol.Remove(0, coincident_text.Length);
                search_buffer += coincident_text + last_symbol;//добавляем в буффер поиска обработанные подстроку и символ, ушедший в метку
                if (search_buffer.Length > search_buffer_size)//если буффер поиска вышел за рамки максимального размера, то 
                    search_buffer = search_buffer.Remove(0, search_buffer.Length - search_buffer_size);// обрезается n первых символов, где n - разница между текущим размером буффера и максимально возможным
                try
                {
                    proactive_buffer = proactive_buffer.Remove(0, coincident_text.Length + 1);//убираем уже обработанные символы из упреждающего буффера
                }
                catch { proactive_buffer = proactive_buffer.Remove(0); }//выполняется, если на текущем шаге в упреждающем буффере остался 1 символ
                result_text += "(" + offset + "," + coincident_text.Length + "," + last_symbol + ") ";//добавление метки в текст, предназначенный для вывода на экран. Метка имеет формат: ("номер позиции начала подстроки из буффера поиска, в которой найдено совпадение","длина подстроки","символ, которым оканчивается совпадающая строка")
            }
            return result_text;//вывод текста в текстовое поле
        }
        public async Task<string> BitmapToString(Bitmap bitmap)
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] imageBytes = stream.ToArray();
            string base64String =Convert.ToBase64String(imageBytes);

            return base64String.ToLower();
        }
      
    }
}
