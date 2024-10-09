using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMVC002.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreMVC002.Controllers
{
    public class GameController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            // 初始化秘密數字
            string secretNumber = GenerateSecretNumber();

            // 傳遞到 View 內部後再回到 Controller
            TempData["secretNumber"] = secretNumber;

            // 創建猜測模型: 猜測數字+比對結果+比對邏輯
            //Console.WriteLine($"Gen num {secretNumber}");
            var model = new XAXBEngine(secretNumber);

            TempData["records"] = "";

            // 使用強型別
            return View(model);
        }

        [HttpPost]
        public ActionResult Guess(XAXBEngine model)
        {
            model.Secret = TempData["secretNumber"] as string;
            TempData.Keep("secretNumber");

            // 檢查猜測結果
            model.Result = GetGuessResult(model);

            model.Records = TempData["records"] as string;
            model.Records += $"{model.Guess}: {model.Result},";
            TempData["records"] = model.Records;
            TempData.Keep("records");

            //Console.WriteLine($"S={model.Secret}, G={model.Guess}, R={model.Result}");
            //
            return View("Index", model);
        }

        // ------ 遊戲相關之邏輯 ------
        private string GenerateSecretNumber()
        {
            // 生成一個隨機的4位數字作為秘密數字
            // 你可以根據需要自定義生成規則
            bool[] numbers = { false, false, false, false, false, false, false, false, false, false };
            string randomSecret = "";
            var rand = new Random();

            int randInt = rand.Next(0, 10);
            numbers[randInt] = true;
            randomSecret += randInt.ToString();

            for (int i = 1; i < 4; i++)
            {
                randInt = rand.Next(0, 10);

                while (numbers[randInt])
                {
                    if (++randInt >= 10)
                    {
                        randInt = 0;
                    }
                }
                numbers[randInt] = true;
                randomSecret += randInt.ToString();
            }
            return randomSecret;
        }

        private string GetGuessResult(XAXBEngine model)
        {
            // 檢查猜測結果，並返回結果字符串
            string secretNumber = TempData["secretNumber"] as string;
            // 利用Keep(...) 方法, or 再次回存！
            // TempData["SecretNumber"] = secretNumber;
            TempData.Keep("secretNumber");

            

            // 你可以根據遊戲規則自定義檢查邏輯
            //if (secretNumber.Equals(model.Guess))
            //    return "4A0B";
            //else
            //    Console.WriteLine($"Secret={model.Secret}");
            return $"{model.numOfA(model.Guess)}A{model.numOfB(model.Guess)}B";
        }
    }
}

