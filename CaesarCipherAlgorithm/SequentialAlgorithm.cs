namespace CaesarCipherAlgorithm{
    public class SequentialAlgorithm{
        static char[] alphabet ={
            'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у',
            'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'
        };

        static int step = 3; // шаг
        static char[] encryptAlp = new char[alphabet.Length];

        public void SeqAl(){
            for (int f = 0; f < 1; f++){
                string encryptedStr = "";
                Random random = new Random();

                for (int i = 0; i < 750000; i++){
                    int letNum = random.Next(alphabet.Length);
                    encryptedStr += alphabet[letNum];
                }

                char[] encryptedChars = encryptedStr.ToLower().ToCharArray();
                char[] encryptedСharsNew = new char[encryptedStr.Length];

                var timeStart = Environment.TickCount;
                for (int i = 0; i < encryptedChars.Length; i++){
                    for (int j = 0; j < alphabet.Length; j++){
                        if (encryptedChars[i] == alphabet[j]){
                            int l = (j + step - 1) % alphabet.Length;
                            encryptedСharsNew[i] = alphabet[l];
                        }
                        else if (encryptedChars[i] == ' '){
                            encryptedСharsNew[i] = ' ';
                        }
                    }
                }

                var timeEnd = Environment.TickCount;

                string encryptedStrNew = new string(encryptedСharsNew);

                Console.WriteLine(timeEnd - timeStart);
                //Console.WriteLine(encryptedStrNew);
            }
        }
    }
}