# Force Clean VS UnUsed Data

A simple yet practical tool for .NET developers to quickly delete unnecessary `bin` and `obj` folders from their projects and solutions. This helps free up disk space and resolve issues caused by leftover build artifacts.

## Features

- Recursively searches for all `bin` and `obj` folders in a specified root directory.
- Deletes found folders and their contents safely.
- Handles access permissions and reports any issues.
- Console-based and easy to use.

## Why use this tool?

During .NET development, `bin` and `obj` folders accumulate build outputs and temporary files. Over time, these can consume significant disk space and sometimes cause build or runtime issues. This tool automates the cleanup process, saving time and effort.

## How to Use

1. **Build the project** using Visual Studio 2022 or the .NET CLI (requires .NET 9).
2. **Run the application.**
3. When prompted, **enter the root path** of your solution or project directory.
4. The tool will search for and delete all `bin` and `obj` folders under the specified path.

## Tutorial
https://youtu.be/I-DfT3N7jwU


The tool will display the folders it deletes and notify you when the process is complete.

## Requirements

- .NET 9 SDK
- Windows OS (recommended)

## License

This project is provided under the MIT License.

---

ابزاری ساده و کاربردی برای حذف پوشه‌های `bin` و `obj` در پروژه‌های دات‌نت، مناسب برای برنامه‌نویسانی که به پاک‌سازی سریع فایل‌های غیرضروری نیاز دارند.
