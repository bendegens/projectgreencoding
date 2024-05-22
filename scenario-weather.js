const visit = async (page) => {
    await page.goto('weather', { waitUntil: 'networkidle' });
    await page.scrollToEnd();
};

module.exports = visit;
