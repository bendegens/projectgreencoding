const visit = async (page) => {
    await page.goto('counter', { waitUntil: 'networkidle' });
    await page.scrollToEnd();
};

module.exports = visit;
