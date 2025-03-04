const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
    entry: './src/app.ts',
    mode: 'development',
    devtool: 'inline-source-map',
    plugins: [
        new HtmlWebpackPlugin({
            template: './public/index.html',
            filename: 'index.html'
        })
    ],
    module: {
        rules: [
            {
                test: /\.ts$/,
                use: 'ts-loader',
                exclude: /node_modules/,
            },
        ],
    },
    resolve: {
        extensions: ['.ts', '.js'],
        alias: {
            'mvp-core': path.resolve(__dirname, '../mvp-core/src')
        }
    },
    output: {
        filename: 'bundle.js',
        path: path.resolve(__dirname, 'wwwroot'),
        publicPath: '/',  // Add this for proper asset resolution
        clean: true
    },
    devServer: {  // Optional: Add for live reloading
        static: {
            directory: path.join(__dirname, 'wwwroot'),
        },
        compress: true,
        port: 9000,
        hot: true
    }
};