const { chromium } = require('playwright');  // or 'firefox' or 'webkit'

(async () => {
    const browser = await chromium.launch({ headless: true });
    const context = await browser.newContext();
    const page = await context.newPage();
    await page.goto('http://localhost:5000/weather');
    // Add the rest of your scenario steps here
    await browser.close();
})();