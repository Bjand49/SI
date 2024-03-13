console.log(new Date());    
console.log(Date());
console.log(Date.now());

const date = new Date();

const danishDate =  Intl.DateTimeFormat("da-DK").format(date);
console.log(danishDate)

const americanDate =  Intl.DateTimeFormat("en-US").format(date);
console.log(americanDate)

