function print(startChar, endChar){
   let result = ``;
   let start = Math.min(startChar.charCodeAt(), endChar.charCodeAt());
   let end = Math.max(startChar.charCodeAt(), endChar.charCodeAt());

   for (let i = start + 1; i < end; i++) {
    let currentChar = String.fromCharCode(i);
    result += `${currentChar} `;
   }

   console.log(result.trimEnd());
}

print(`a`, `d`);
print(`#`, `:`);
print(`C`, `#`);