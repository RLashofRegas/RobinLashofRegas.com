module.exports = {
    root: true,
    parser: '@typescript-eslint/parser',
    parserOptions: {
        tsconfigRootDir: __dirname,
        project: ['./tsconfig.eslint.json', './src/webspa/tsconfig.json']
    },
    plugins: [
        '@typescript-eslint',
        'jasmine',
        'protractor',
        'angular'
    ],
    extends: [
        'eslint:recommended',
        'plugin:@typescript-eslint/recommended',
        'plugin:@typescript-eslint/recommended-requiring-type-checking'
    ],
    env: {
        'browser': true,
        'amd': true,
        'node': true,
        'jasmine': true,
        'protractor': true
    }
};
