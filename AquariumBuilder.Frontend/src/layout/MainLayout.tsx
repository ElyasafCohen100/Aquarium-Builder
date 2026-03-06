import React from "react";
import HeaderComponent from "../components/Header/HeaderComponent";


type MainLayoutProps = {
    children: React.ReactNode;
};

export default function MainLayout({ children }: MainLayoutProps) {
    return (
        <>
            <HeaderComponent />
            <main>{children}</main>
        </>
    );
}