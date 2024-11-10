using System;
using System.Linq;

namespace api.healthy.src.components.utils
{
    public static class CpfValidator
    {
        public static bool IsValidCPF(long cpf)
        {
            // Verifica se o CPF possui exatamente 11 dígitos e se todos os dígitos são iguais
            if (GetDigitsCount(cpf) != 11 || AllDigitsAreEqual(cpf))
                return false;

            // Extrair os primeiros 9 dígitos
            long baseCpf = cpf / 100;

            // Calcular os dois dígitos verificadores
            int digit1 = CalculateDigit(baseCpf, 10);
            int digit2 = CalculateDigit(baseCpf * 10 + digit1, 11);

            // Extrair os dois últimos dígitos do CPF original
            int lastDigit1 = (int)((cpf / 10) % 10);
            int lastDigit2 = (int)(cpf % 10);

            // Validar os dígitos calculados com os do CPF original
            return digit1 == lastDigit1 && digit2 == lastDigit2;
        }

        // Método para contar o número de dígitos usando logaritmo
        private static int GetDigitsCount(long number)
        {
            if (number == 0) return 1;
            return (int)Math.Floor(Math.Log10(Math.Abs(number)) + 1);
        }

        // Método para verificar se todos os dígitos são iguais
        private static bool AllDigitsAreEqual(long number)
        {
            string numStr = number.ToString();
            return numStr.All(c => c == numStr[0]);
        }

        // Método para calcular o dígito verificador
        private static int CalculateDigit(long baseCpf, int weight)
        {
            int sum = 0;
            while (baseCpf > 0)
            {
                sum += (int)(baseCpf % 10) * weight--;
                baseCpf /= 10;
            }
            int remainder = (sum * 10) % 11;
            return remainder == 10 ? 0 : remainder;
        }
    }
}
