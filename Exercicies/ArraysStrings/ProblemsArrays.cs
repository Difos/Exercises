using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using Utils;

namespace ArraysStrings
{
    public class ProblemsArray
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };
                }

                map[nums[i]] = i;
            }

            throw new ArgumentException("No two sum solution");
        }

        public static int[][] Merge(int[][] intervals)
        {
            if (intervals.Length == 0) return new int[0][];

            // Ordenar diretamente o array (mais eficiente que OrderBy)
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            List<int[]> merged = new List<int[]>();
            int[] currentInterval = intervals[0];
            merged.Add(currentInterval);

            foreach (var interval in intervals)
            {
                int currentEnd = currentInterval[1];
                int nextStart = interval[0];
                int nextEnd = interval[1];

                if (nextStart <= currentEnd)
                {
                    // Mescla os intervalos sobrepostos ajustando o final
                    currentInterval[1] = Math.Max(currentEnd, nextEnd);
                }
                else
                {
                    // Adiciona um novo intervalo e atualiza o intervalo atual
                    currentInterval = interval;
                    merged.Add(currentInterval);
                }
            }

            return merged.ToArray();
        }
        public static int LenghtOfLongestSubstring(string s)
        {
            int n = s.Length;
            int maxLength = 0;
            int left = 0;

            Dictionary<char, int> charIndexMap = new Dictionary<char, int>();

            for (int right = 0; right < n; right++)
            {
                if (charIndexMap.ContainsKey(s[right]))
                {
                    left = Math.Max(charIndexMap[s[right]] + 1, left);
                }
                maxLength = Math.Max(maxLength, right - left + 1);

                charIndexMap[s[right]] = right;
            }

            return maxLength;
        }

        public static int maximumLenghtSubstring(string s)
        {
            int l = 0, r = 0;
            int _max = 0;

            Dictionary<char, int> counter = new Dictionary<char, int>();

            counter[s[0]] = 1;

            while (r < s.Length - 1)
            {
                r++;
                if (counter.ContainsKey(s[r]))
                {
                    counter[s[r]]++;
                }
                else
                {
                    counter[s[r]] = 1;
                }

                while (counter[s[r]] == 3)
                {
                    counter[s[l]]--;
                    l++;
                }

                _max = Math.Max(_max, r - l + 1);
            }

            return _max;

        }
        public static string MostCommonWord(string paragraph, string[] banned)
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            // Normaliza e remove pontuação
            paragraph = Regex.Replace(paragraph.ToLower(), "[^a-zA-Z\\s]", " ");
            paragraph = Regex.Replace(paragraph, "\\s+", " ").Trim();

            // Divide em palavras
            string[] words = paragraph.Split(' ');

            // Converte lista de banidos em HashSet para busca eficiente
            HashSet<string> bannedWords = new HashSet<string>(banned);

            // Contagem de palavras
            foreach (string word in words)
            {
                if (!bannedWords.Contains(word)) // Se não está na lista de banidos
                {
                    if (wordCounts.ContainsKey(word))
                    {
                        wordCounts[word]++;
                    }
                    else
                    {
                        wordCounts[word] = 1;
                    }
                }
            }

            // Retorna a palavra mais comum (que não está banida)
            return wordCounts.OrderByDescending(kvp => kvp.Value).FirstOrDefault().Key ?? "";
        }
        public static int MyAtoi(string s)
        {
            s = s.TrimStart();
            if (string.IsNullOrEmpty(s)) return 0;

            int i = 0, sign = 1;
            long result = 0;

            if (s[i] == '-' || s[i] == '+')
            {
                sign = (s[i] == '-') ? -1 : 1;
                i++;
            }

            while (i < s.Length && char.IsDigit(s[i]))
            {
                result = result * 10 + (s[i] - '0');

                if (sign * result < int.MinValue) return int.MinValue;
                if (sign * result > int.MaxValue) return int.MaxValue;

                i++;
            }

            return (int)(sign * result);
        }
        public static void reverseString(char[] s)
        {
            if (s.Length == 0)
            {
                Console.WriteLine("[]");
                return;
            }

            int left = 0, right = s.Length - 1;

            while (left < right)
            {
                char temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                left++;
                right--;
            }

            Console.WriteLine("[\"" + string.Join("\", \"", s) + "\"]");
        }
        public static void reverseString2(char[] s)
        {
            int j = 0;
            char[] r = new char[s.Length];
            if (s.Length == 0)
            {
                Console.WriteLine("[]");
            }

            for (int i = s.Length - 1; i > 0; i--)
            {
                r[j] = s[i];

                j++;
            }

            s = r;
            Console.WriteLine("[\"" + string.Join("\", \"", s) + "\"]");
        }
        public static int SearchBinaryTreeExp(int[] nums, int target, int low, int high)
        {
            int lenArr = nums.Length;
            int lowPos = 0;
            int highPos = lenArr;

            while (lowPos < highPos)
            {
                int middle = lowPos + (highPos - lowPos) / 2;

                if (nums[middle] == target)
                {
                    return middle;
                }

                if (nums[middle] < target)
                {
                    lowPos = middle + 1;
                }
                else
                {
                    highPos = middle;
                }
            }

            return -1;
        }
        public static int SearchExponential(int[] nums, int target)
        {
            if (nums[0] == target) return 0;
            if (nums.Length == 0) return -1;
            int n = nums.Length;

            int i = 1;

            while (i < n && nums[i] < target)
            {
                i *= 2;
            }

            int low = i / 2;
            int high = Math.Min(i, n - 1);

            return SearchBinaryTreeExp(nums, target, low, high);

        }
        public static int FirstUniqChar(string s)
        {
            Dictionary<char, int> freq = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (freq.ContainsKey(c))
                {
                    freq[c]++;
                }
                else
                    freq[c] = 1;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (freq[s[i]] == 1)
                    return i;
            }

            return -1;

        }
        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]))
                {

                    if (i - map[nums[i]] <= k)
                        return true;

                }
                map[nums[i]] = i;
            }

            return false;
        }

        public int MaxArea(int[] height)
        {
            //complexidade O(n)
            int left = 0, right = height.Length - 1;
            int max_waters = 0, water = 0, width = 0;

            while (left < right)
            {
                width = right - left;
                water = Math.Min(height[left], height[right]) * width;
                max_waters = Math.Max(max_waters, water);

                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return max_waters;
        }

        public static string IntToRoman(int num)
        {
            var romanMap = new Dictionary<int, string>
            {
               { 1000, "M" }, { 900, "CM" }, { 500, "D" }, { 400, "CD" },
            { 100, "C" }, { 90, "XC" }, { 50, "L" }, { 40, "XL" },
            { 10, "X" }, { 9, "IX" }, { 5, "V" }, { 4, "IV" },
            { 1, "I" }
            };

            StringBuilder result = new StringBuilder();

            foreach (var kvp in romanMap)
            {
                int value = kvp.Key;
                string symbol = kvp.Value;

                while (num >= value)
                {
                    result.Append(symbol);
                    num -= value;
                }
            }

            return result.ToString();
        }

        public static int RomanToInt(string s)
        {
            var romanMap = new Dictionary<char, int>
            {
                { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 },
                { 'C', 100 }, { 'D', 500 }, { 'M', 1000 }
            };

            int result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int currentValue = romanMap[s[i]];

                if (i < s.Length - 1 && currentValue < romanMap[s[i + 1]])
                {
                    result -= currentValue;
                }
                else
                {
                    result += currentValue;
                }
            }

            return result;
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);

            List<IList<int>> result = new List<IList<int>>();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                int left = i + 1, right = nums.Length - 1;

                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];

                    if (sum == 0)
                    {
                        result.Add(new List<int> { nums[i], nums[left], nums[right] });

                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;

                        left++;
                        right--;
                    }
                    else if (sum < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }

            }
            return result;
        }

        public static int ThreeSumClosest(int[] nums, int target)
        {

            Array.Sort(nums);

            int result = nums[0] + nums[1] + nums[2];

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                int left = i + 1, right = nums.Length - 1;

                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];

                    if (sum == target)
                        return sum;

                    if (Math.Abs(sum - target) < Math.Abs(result - target))
                    {
                        result = sum;
                    }

                    if (sum < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return result;
        }

        public static int MinDifficulty(int[] jobDifficulty, int d)
        {
            int n = jobDifficulty.Length;
            if (n < d) return -1; // If it's impossible to schedule

            // dp[i,k] represents the minimum difficulty to schedule first i jobs in k days
            int[,] dp = new int[n, d + 1];
            int maxDifficulty;

            // Initialize dp array
            dp[0, 1] = jobDifficulty[0];
            for (int i = 1; i < n; i++)
            {
                dp[i, 1] = Math.Max(dp[i - 1, 1], jobDifficulty[i]);
            }

            // Fill dp table
            for (int k = 2; k <= d; k++)
            { // number of days
                for (int i = k - 1; i < n; i++)
                { // number of jobs
                    maxDifficulty = jobDifficulty[i];
                    dp[i, k] = int.MaxValue;

                    for (int j = i; j >= k - 1; j--)
                    { // backward to find the best group
                        maxDifficulty = Math.Max(maxDifficulty, jobDifficulty[j]);
                        dp[i, k] = Math.Min(dp[i, k], dp[j - 1, k - 1] + maxDifficulty);
                    }
                }
            }

            return dp[n - 1, d];
        }
        public static int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle)) return 0; // Se needle for vazia, retornamos 0

            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                if (haystack.Substring(i, needle.Length) == needle)
                {
                    return i; // Retorna a posição onde `needle` começa
                }
            }

            return -1; // Retorna -1 se `needle` não for encontrada
        }

        public static void Rotate(int[][] matrix)
        {
            int n = matrix.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[i][n - j - 1];
                    matrix[i][n - j - 1] = temp;
                }
            }
        }

        public static int NumIdenticalPairs(int[] nums)
        {
            Dictionary<int, int> goodPairs = new Dictionary<int, int>();
            int count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (goodPairs.ContainsKey(nums[i]))
                {
                    goodPairs[nums[i]]++;
                    count++;
                }
                else
                {
                    goodPairs[nums[i]] = 1;
                }
            }
            return count;
        }

        public static int Rob(int[] nums)
        {
            //O(1) espacial
            //O(n) temporal todos elementos vai ser percorrido 1 vez

            // Iteração	n	temp (Max)	        two_before	 one_before
            // Início	-	-	0	0
            // 1 (n=2)	2	max(2+0, 0) = 2	    0 → 0	     0 → 2
            // 2 (n=7)	7	max(7+0, 2) = 7	    2 → 2	     2 → 7
            // 3 (n=9)	9	max(9+2, 7) = 11    7 → 7	     7 → 11
            // 4 (n=3)	3	max(3+7, 11) = 11   11 → 11	     11 → 11
            // 5 (n=1)	1	max(1+11, 11) = 12  11 → 11	     11 → 12

            int one_before = 0, two_before = 0;

            foreach (var n in nums)
            {
                var temp = Math.Max(n + two_before, one_before);
                two_before = one_before;
                one_before = temp;
            }

            return one_before;
        }

        public static IList<string> MostVisitedPattern(string[] username, int[] timestamp, string[] website)
        {
            var combined = new (string user, int time, string site)[username.Length];
            for (int i = 0; i < username.Length; i++)
                combined[i] = (username[i], timestamp[i], website[i]);
            Array.Sort(combined, (a, b) => a.time.CompareTo(b.time));

            // Passo 2: Agrupar por usuário (já ordenado)
            var userVisits = new Dictionary<string, List<string>>();
            foreach (var entry in combined)
            {
                if (!userVisits.ContainsKey(entry.user))
                    userVisits[entry.user] = new List<string>();
                userVisits[entry.user].Add(entry.site);
            }

            // Passo 3: Contar padrões com Dictionary e string como chave
            var freq = new Dictionary<string, int>();
            string maxKey = "";
            int maxCount = 0;

            foreach (var (user, sites) in userVisits)
            {
                if (sites.Count < 3) continue;
                var localSeen = new HashSet<string>(); // Evita duplicatas por usuário

                for (int i = 0; i < sites.Count; i++)
                {
                    for (int j = i + 1; j < sites.Count; j++)
                    {
                        for (int k = j + 1; k < sites.Count; k++)
                        {
                            // Usa string como chave (mais rápida que Tuple)
                            string key = $"{sites[i]},{sites[j]},{sites[k]}";
                            if (localSeen.Add(key))
                            { // Add retorna true se a chave for nova
                                freq.TryGetValue(key, out int count);
                                freq[key] = count + 1;

                                // Atualiza máximo durante a contagem
                                if (count + 1 > maxCount || (count + 1 == maxCount && string.Compare(key, maxKey) < 0))
                                {
                                    maxCount = count + 1;
                                    maxKey = key;
                                }
                            }
                        }
                    }
                }
            }

            return maxKey.Split(',').ToList();
        }
        public static int BestDishes(int n, int[][] ratings)
        {
            // Dicionario para armazenar soma e contagem de avaliacao por prato
            Dictionary<int, (int sum, int count)> dishData = new Dictionary<int, (int sum, int count)>();

            //Processa cada avaliacao
            foreach (var entry in ratings)
            {
                int dishId = entry[0];
                int rating = entry[1];

                if (dishData.ContainsKey(dishId))
                {
                    var current = dishData[dishId];
                    dishData[dishId] = (current.sum + rating, current.count + 1);
                }
                else
                {
                    dishData[dishId] = (rating, 1); //adiciona o novo prato
                }
            }

            double maxAvg = -1; //Inicializa com valor minimo
            int bestId = -1;// Id do melhor prato

            foreach (var kvp in dishData)
            {
                int currentId = kvp.Key;
                int sum = kvp.Value.sum;
                int count = kvp.Value.count;

                double avg = (double)sum / count;

                if (avg > maxAvg)
                {
                    maxAvg = avg;
                    bestId = currentId;
                }
                else if (avg == maxAvg)
                {
                    if (currentId < bestId)
                    {
                        bestId = currentId;
                    }
                }
            }

            return bestId;

        }

        public static string[] ReorderLogFiles(string[] logs)
        {
            //Criamos duas listas para armazenar os logs de letras e os logs numéricos
            // O(n) - Espaço adicional necessário para armazenar os logs separados
            List<string> letterLogs = new List<string>();
            List<string> digitLogs = new List<string>();

            // Percorremos todos os logs
            // O(n) - pois percorremos cada log uma vez
            foreach (string log in logs)
            {
                // Encontramos o primeiro espaço para separar o identificador do conteúdo
                int firstSpaceIndex = log.IndexOf(' ');
                string content = log.Substring(firstSpaceIndex + 1);

                // Verificamos se o primeiro caractere do conteúdo é uma letra
                if (char.IsLetter(content[0]))
                {
                    letterLogs.Add(log); // O(1) - Adicionamos o log à lista de letras
                }
                else
                {
                    digitLogs.Add(log); // O(1) - Adicionamos o log à lista de números
                }
            }

            // Ordenamos os logs de letras
            // O(m log m), onde m é o número de logs de letras
            var sortedLetterLogs = letterLogs
                .OrderBy(log =>
                {
                    int spaceIndex = log.IndexOf(' ');
                    return log.Substring(spaceIndex + 1); // Ordenação principal: conteúdo do log
                })
                .ThenBy(log =>
                {
                    int spaceIndex = log.IndexOf(' ');
                    return log.Substring(0, spaceIndex); // Ordenação secundária: identificador
                })
                .ToList();

            // Concatenamos os logs ordenados de letras com os logs numéricos
            // O(n) - pois estamos apenas unindo duas listas
            return sortedLetterLogs.Concat(digitLogs).ToArray();
        }

        public static int Trap(int[] height)
        {

            int totalWaterTraped = 0, l = 0, r = height.Length - 1;
            int lmax = 0, rmax = r;

            while (l < r)
            {
                if (height[l] <= height[r])
                {
                    if (height[l] < lmax)
                    {
                        totalWaterTraped += lmax - height[l];
                    }
                    else
                    {
                        lmax = height[l];
                    }
                    l++;
                }
                else
                {
                    if (height[r] < rmax)
                    {
                        totalWaterTraped += rmax - height[r];
                    }
                    else
                    {
                        rmax = height[r];
                    }
                    l--;
                }
            }

            return totalWaterTraped;

        }

        public static int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0) return 0;

            int count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        DFSIslands(grid, i, j);
                        count++;
                    }
                }
            }

            return count;
        }

        public static void DFSIslands(char[][] grid, int i, int j)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] != '1')
            {
                return;
            }

            grid[i][j] = '0';
            DFSIslands(grid, i + 1, j);
            DFSIslands(grid, i - 1, j);
            DFSIslands(grid, i, j + 1);
            DFSIslands(grid, i, j - 1);
        }

        public static int MinTransfers(int[][] transactions)
        {
            //Passo 1: Calcular o saldo liquido de cada pessoa
            Dictionary<int, int> balances = new Dictionary<int, int>();
            foreach (var t in transactions)
            {
                int sender = t[0], receiver = t[1], amount = t[2];

                balances.TryAdd(sender, 0);
                balances.TryAdd(receiver, 0);

                balances[sender] -= amount;
                balances[receiver] += amount;

            }

            //passo 2: Extrair saldos nao zero (dividas a serem resolvidas)
            List<int> debts = balances.Values.Where(x => x != 0).ToList();
            debts.Sort((a, b) => Math.Abs(b).CompareTo(Math.Abs(a)));
            //passo 3: Backtracking para encontrar o minimo de transacoes
            return Backtrack(debts, 0);
        }

        public static int Backtrack(List<int> debts, int start)
        {
            //ignora saldos ja zerados
            while (start < debts.Count && debts[start] == 0)
            {
                start++;
            }

            //Caso base: todos os saldos foram resolvidos
            if (start == debts.Count) return 0;

            int minTransactions = int.MaxValue;

            //Tenta combinar a divida atual (start) com outras dividas
            for (int i = start + 1; i < debts.Count; i++)
            {
                //so combina dividas de sinais opostos
                if (debts[i] * debts[start] < 0)
                {
                    //simula uma transacao entre start e i
                    debts[i] += debts[start]; //transfere a divida 
                    //conta a transação atual que está sendo simulada o primeiro +1 e o segundo
                    //avança para o próximo índice na lista de dívidas, indicando que a dívida atual (start) já foi processada.
                    //1 + é essencial para acumular o número de transações ao longo da recursão
                    /*1 +: Contabiliza a transação atual.
                    t + 1: Avança na lista de dívidas para evitar repetições.*/
                    minTransactions = Math.Min(minTransactions, 1 + Backtrack(debts, start + 1));
                    debts[i] -= debts[start]; //Backtrack(dezfaz a transcao)
                }
            }

            return minTransactions == int.MaxValue ? 0 : minTransactions;
        }

    }

    public class Logger
    {

        private Dictionary<string, int> _messageTimeStamps;
        public Logger()
        {
            _messageTimeStamps = new Dictionary<string, int>();
        }

        public bool ShouldPrintMessage(int timestamp, string message)
        {
            if (_messageTimeStamps.ContainsKey(message))
            {
                if (timestamp - _messageTimeStamps[message] < 10)
                {
                    return false;
                }
            }

            _messageTimeStamps[message] = timestamp;
            return true;

        }
    }

    public class H2O
    {

        private int hydrogenCount = 0;
        private SemaphoreSlim hydrogenSem = new SemaphoreSlim(2);
        private SemaphoreSlim oxygenSem = new SemaphoreSlim(1);
        private object lockObject = new object();
        public H2O()
        {

        }

        public void Hydrogen(Action releaseHydrogen)
        {
            hydrogenSem.Wait();
            lock (lockObject)
            {
                releaseHydrogen();
                hydrogenCount++;
                if (hydrogenCount % 2 == 0)
                {
                    oxygenSem.Release();
                }
            }

        }

        public void Oxygen(Action releaseOxygen)
        {
            oxygenSem.Wait();
            releaseOxygen();
            hydrogenSem.Release(2);
        }
    }
}