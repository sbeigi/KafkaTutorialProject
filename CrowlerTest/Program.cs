using Microsoft.Playwright;

string url = @"https://www.digikala.com/product/dkp-16166965/%DA%AF%D9%88%D8%B4%DB%8C-%D9%85%D9%88%D8%A8%D8%A7%DB%8C%D9%84-%D8%B3%D8%A7%D9%85%D8%B3%D9%88%D9%86%DA%AF-%D9%85%D8%AF%D9%84-galaxy-m14-4g-%D8%AF%D9%88-%D8%B3%DB%8C%D9%85-%DA%A9%D8%A7%D8%B1%D8%AA-%D8%B8%D8%B1%D9%81%DB%8C%D8%AA-64-%DA%AF%DB%8C%DA%AF%D8%A7%D8%A8%D8%A7%DB%8C%D8%AA-%D9%88-%D8%B1%D9%85-4-%DA%AF%DB%8C%DA%AF%D8%A7%D8%A8%D8%A7%DB%8C%D8%AA-%D8%A7%DA%A9%D8%AA%DB%8C%D9%88/";
using var playwright = await Playwright.CreateAsync();
await using var browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
{
    Headless = true // run in headless mode
});

// Create a new browser context to simulate a real browser session.
var context = await browser.NewContextAsync(new BrowserNewContextOptions
{
    UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) " +
                "AppleWebKit/537.36 (KHTML, like Gecko) " +
                "Chrome/115.0.0.0 Safari/537.36",
    ViewportSize = new ViewportSize { Width = 1280, Height = 720 }
});

var page = await context.NewPageAsync();
await page.GotoAsync(url, new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });

// Optionally wait for a specific selector that confirms content is loaded.
await page.WaitForSelectorAsync("div.content");

// Extract the page content or specific elements.
var content = await page.ContentAsync();
Console.WriteLine("Dynamic Page Content:");
Console.WriteLine(content.Substring(0, Math.Min(content.Length, 500))); // Print first 500 characters

// You can also extract text from specific elements:
var title = await page.InnerTextAsync("ml-1 text-neutral-800 text-h4-compact");
Console.WriteLine($"Extracted Title: {title}");