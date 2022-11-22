namespace CaesarCipherAlgorithm;

public class ParallelAlgorithm{
    static char[] alphabet ={
        'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф',
        'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'
    };

    static int step = 3; // шаг
    static char[] encryptAlp = new char[alphabet.Length];

    public void ParallelAl(){
        for (int f = 0; f < 1; f++){
            string encryptedStr = "";
            Random random = new Random();

            for (int i = 0; i < 1000000; i++){
                int letNum = random.Next(alphabet.Length);
                encryptedStr += alphabet[letNum];
            }

            char[] encryptedChars = encryptedStr.ToLower().ToCharArray();
            object encryptedСharsNew = new char[encryptedStr.Length];

            var timeStart = Environment.TickCount;
            for (int i = 0; i < encryptedChars.Length; i++){
                int i1 = i;

                Task task = new Task(() => EncryptStrTask(i1, encryptedChars[i1], ref encryptedСharsNew));
                task.Start();
            }

            var timeEnd = Environment.TickCount;

            Thread.Sleep(500);

            char[] encryptedCharsNew = (char[])encryptedСharsNew;
            string encryptedStrNew = new string(encryptedCharsNew);

            Console.WriteLine(timeEnd - timeStart);
            //Console.WriteLine(encryptedStrNew);
        }
    }

    private static void EncryptStrTask(object i, object leter, ref object encr){
        for (int j = 0; j < alphabet.Length; j++){
            if ((char)leter == alphabet[j]){
                int l = (j + step - 1) % alphabet.Length;
                ((char[])encr)[(int)i] = alphabet[l];
            }
            else if ((char)leter == ' '){
                ((char[])encr)[(int)i] = ' ';
            }
        }
    }
}